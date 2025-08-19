document.addEventListener("DOMContentLoaded", () => {
    const form = document.getElementById("filter-form");
    const resultsContainer = document.getElementById("results-container");
    const paging = document.getElementById("pagination-container");
    const dataCount = document.getElementById("order-count");
    const dataTotal = document.getElementById("order-total");

    function fetchData(extraParams = {})
    {
        const formData = new FormData(form);
        const params = new URLSearchParams(formData);

        //overwrite params iof needed 
        for (const [key, value] of Object.entries(extraParams))
        {
            params.set(key, value);
        }

        //format for ZAR 
        const formatToZar = new Intl.NumberFormat('en-ZA', {
            style: 'currency',
            currency: 'ZAR'
        });

        fetch(`/OrderViewer/OrderViewerData?${params.toString()}`, {
            headers: { "X-Requested-With": "XMLHttpRequest" }
        })
            .then(res => res.json())
            .then(data => {
                resultsContainer.innerHTML = data.table.content;
                paging.innerHTML = data.pagination.content;
                dataCount.textContent = data.summary.count;
                dataTotal.textContent = formatToZar.format(data.summary.grandTotal);
            })
            .catch(err => console.error("Fetch error: ", err));
    }
    //invoke on page load
    fetchData();

    //trigger on filter changes
    form.querySelectorAll("input, select").forEach(input => {
        ["change", "input"].forEach(eventType => {
            input.addEventListener(eventType, fetchData)
        });
    });

    //paging click event
    document.addEventListener("click", function (e) {
        const link = e.target.closest("a.page-link");
        if (!link) return;
        e.preventDefault();
        fetchData({ PageNumber: link.dataset.page });
    });
});