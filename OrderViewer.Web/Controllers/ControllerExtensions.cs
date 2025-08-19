using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace OrderViewer.Web.Controllers
{
    public static class ControllerExtensions
    {
        public static async Task<ContentResult> RenderViewAsync<TModel>(
                this Controller controller, string viewName, TModel model, bool partial = false
            )
        { 
            var services = controller.HttpContext.RequestServices;
            var viewEngine = services.GetService<IRazorViewEngine>();
            var tempDataProvider = services.GetService<ITempDataProvider>();

            var actionContext = new ActionContext(
                    controller.HttpContext,
                    controller.RouteData,
                    controller.ControllerContext.ActionDescriptor
                );

            using var sw = new StringWriter();

            var viewResult = viewEngine.FindView(actionContext, viewName, !partial);
            if (viewResult.View == null)
            {
                throw new ArgumentNullException($"{viewName} not found");
            }

            var viewDictionary = new ViewDataDictionary<TModel>(new EmptyModelMetadataProvider(), new ModelStateDictionary())
            {
                Model = model
            };

            var tempData = new TempDataDictionary(controller.HttpContext, tempDataProvider);

            var viewContext = new ViewContext(actionContext, viewResult.View, viewDictionary, tempData, sw, new HtmlHelperOptions());

            await viewResult.View.RenderAsync(viewContext);
            return new ContentResult
            {
                Content = sw.ToString(),
                ContentType = "text/html"
            };
        }
    }
}
