document.addEventListener("DOMContentLoaded", function () {
    // Event delegation so it works after partial reload
    document.querySelector("#results-container").addEventListener("click", function (e) {
        let row = e.target.closest(".order-row");
        if (!row) return;

        let orderId = row.getAttribute("data-order-id");
        console.log("OrderId: ", orderId);
        toggleOrderItems(orderId);
    });
});
function toggleOrderItems(orderId) {
    const detailsRow = document.getElementById(`order-items-${orderId}`);
    if (!detailsRow) return;

    if (detailsRow.style.display === '' || detailsRow.style.display === 'none') {

        //show this row
        detailsRow.style.display = 'table-row';

        //load items
        document.getElementById(`order-items-content-${orderId}`).innerHTML = '<em>Loading...</em>';
        fetch(`/OrderViewer/GetOrderItems?OrderId=${orderId}`)
            .then(response => {
                if (!response.ok)
                    throw new Error("Network response was not ok");
                return response.text();
            })
            .then(html => {
                document.getElementById(`order-items-content-${orderId}`).innerHTML = html;
            }).catch(err => console.error("faisl to load order items", err));

    } else {
        detailsRow.style.display = 'none';
    }

}