var popoverTriggerList = [].slice.call(document.querySelectorAll('[data-bs-toggle="popover"]'));
var popoverList = popoverTriggerList.map(function (popoverTriggerEl) {
    return new bootstrap.Popover(popoverTriggerEl);
})

document.querySelectorAll('.btn-edit').forEach((b) => {
    b.addEventListener('click', (e) => {
        const form = document.querySelector("form");
        var id = e.target.dataset.id;
        document.querySelector("#act").value = "edit";
        document.querySelector("#contact-id").value = id;
        form.action = "/edit";
        form.submit();
    });
})

