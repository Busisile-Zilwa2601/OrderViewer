function getFormUrl() {
    const params = new URLSearchParams(new FormData(document.getElementById("filter-form")));
    return `/OrderViewer/OrderViewerIndex?${params.toString()}`;
}

function fetchFilteredOrders() {
    fetch(getFormUrl(), {
            headers: {
                "X-Requested-With": "XMLHttpRequest"
            }
        })
        .then(res => res.text())
        .then(html => {
            const temp = document.createElement("div");
            temp.innerHTML = html;
            console.log(html);
            const newTbody = temp.querySelector("#results-container");
            const newPager = temp.querySelector("#pagination-container");

            const oldTbody = document.querySelector("#results-container");
            const oldPager = document.querySelector("#pagination-container");

            //document.getElementById("results-container").innerHTML = html;
            if (newTbody && oldTbody) oldTbody.innerHTML = newTbody.innerHTML;
            if (newPager && oldPager) oldPager.outerHTML = newPager.outerHTML;
        })
        .catch(err => console.error("Fetch error:", err));
}





document.addEventListener("DOMContentLoaded", () => {

    fetchFilteredOrders();

    const form = document.getElementById("filter-form");

    // Submit on input or select change
    form.querySelectorAll("input, select").forEach(input => {
        input.addEventListener("change", fetchFilteredOrders);
    });

    // Pagination click (event delegation survives DOM replace)
    document.addEventListener("click", function (e) {
        // Find closest link with class "page-link"
        const link = e.target.closest("a.page-link");
        if (!link) return; // Exit if not a pagination link

        e.preventDefault();

        // Remove old PageNumber input if it exists
        let pageInput = form.querySelector("input[name=PageNumber]");
        if (pageInput) {
            pageInput.value = link.dataset.page; // just update value
        } else {
            // Or create new hidden input
            pageInput = document.createElement("input");
            pageInput.type = "hidden";
            pageInput.name = "PageNumber";
            pageInput.value = link.dataset.page;
            form.appendChild(pageInput);
        }

        fetchFilteredOrders(); // trigger AJAX fetch
    });

});
// Page size change → reset to page 1
document.getElementById("pageSize").addEventListener("change", function () {
    form.querySelector("input[name=PageSize]")?.remove();
    const size = document.createElement("input");
    size.type = "hidden";
    size.name = "PageSize";
    size.value = this.value;
    form.appendChild(size);

    form.querySelector("input[name=PageNumber]")?.remove();
    const page = document.createElement("input");
    page.type = "hidden";
    page.name = "PageNumber";
    page.value = "1";
    form.appendChild(page);

    fetchFilteredOrders();
});
