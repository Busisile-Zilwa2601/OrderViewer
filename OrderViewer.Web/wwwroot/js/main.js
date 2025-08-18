document.addEventListener("DOMContentLoaded", () => {
    const form = document.getElementById("filter-form");
    const resultsContainer = document.getElementById("results-container");
    const paging = document.getElementById("pagination-container");
    function fetchFilteredOrders() {
        const formData = new FormData(form);
        const params = new URLSearchParams(formData).toString();

        fetch(`/OrderViewer/OrderViewerIndex?${params}`, {
            headers: {
                "X-Requested-With": "XMLHttpRequest"
            }
        })
            .then(res => res.text())
            .then(html => {
                resultsContainer.innerHTML = html;
            })
            .catch(err => console.error("Fetch error:", err));
    }

    function fetchPagination()
    {
        const formData = new FormData(form);
        const params = new URLSearchParams(formData).toString();

        fetch(`/OrderViewer/OrderPaginationPartial?${params}`, {
            headers: {
                "X-Requested-With": "XMLHttpRequest"
            }
        })
            .then(res => res.text())
            .then(html => {
                paging.innerHTML = html;
            });
    }

    // Submit on input or select change
    form.querySelectorAll("input, select").forEach(input => {
        input.addEventListener("change", () => {
            fetchFilteredOrders();
            fetchPagination();
        });
    });

    // Submit on pagination link click
    document.addEventListener("click", function (e) {
        const link = e.target.closest("a.page-link");
        if (!link) return;

        e.preventDefault();
        // get current filters from form
        const formData = new FormData(form);
        const params = new URLSearchParams(formData);

        // overwrite PageNumber with the clicked one
        params.set("PageNumber", link.dataset.page);

        // fetch table
        fetch(`/OrderViewer/OrderViewerIndex?${params.toString()}`, {
            headers: { "X-Requested-With": "XMLHttpRequest" }
        })
        .then(res => res.text())
        .then(html => {
            resultsContainer.innerHTML = html;
        });

        // fetch pagination
        fetch(`/OrderViewer/OrderPaginationPartial?${params.toString()}`, {
            headers: { "X-Requested-With": "XMLHttpRequest" }
        })
        .then(res => res.text())
        .then(html => {
            paging.innerHTML = html;
        });
    });
});