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

    //mark paid checkbox
    document.addEventListener("change", async function (e) {
        const checkbox = e.target.closest(".mark-paid-checkbox");
        if (!checkbox) return;
        e.preventDefault();
        console.log(checkbox);
        const orderId = checkbox.getAttribute("data-order-id");
        const spinner = document.getElementById("table-spinner");

        try {
            //show spinner
            spinner.style.display = "flex";

            const response = await fetch(`/OrderViewer/MarkOrderPaid/${orderId}`, {
                method: "POST",
                headers: {
                    "X-Requested-With": "XMLHttpRequest",
                    "Content-Type": "application/json"
                }
            });

            const results = await response.json();
            if (!results.success) {
                throw new Error(results.message || "Failed to mark paid");
            }

            //Update Row
            const row = document.querySelector(`#order-${orderId}`);
            row.classList.add("paid-row");
            checkbox.disabled = true;

            //reload the with the paramaters
            fetchData();

        } catch (err) {
            console.error(err);
            checkbox.checked = false;
        } finally {
            //hide spinner
            spinner.style.display = "none";
        }
    })
});