document.querySelectorAll(".btn-excluir").forEach(b => {
    b.addEventListener("click", (e) => {
        const btn = e.target;
        const id = btn.dataset.id;
        if (confirm("Confirma?")) {
            document.querySelector('[data-id ="' + id + '"]').remove();
            document.forms[0].submit();
        }
    });
});

