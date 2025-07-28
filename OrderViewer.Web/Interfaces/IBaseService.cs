using OrderViewer.Web.Models;

namespace OrderViewer.Web.Interfaces
{
    public interface IBaseService
    {
        Task<ResponseDto<T>?> SendAsync<T>(RequestDto responseDto);
    }
}
