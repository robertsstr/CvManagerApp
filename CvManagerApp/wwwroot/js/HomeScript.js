document.addEventListener("DOMContentLoaded", function () {
    const cvRows = document.querySelectorAll('.cv-row');
    cvRows.forEach(row => {
        row.addEventListener('click', function () {
            const cvId = row.getAttribute('data-cv-id');
            viewFullCV(cvId);
        });
        row.addEventListener('mouseover', function () {
            row.style.cursor = 'pointer';
            row.style.backgroundColor = '#f0f0f0';
        });
        row.addEventListener('mouseout', function () {
            row.style.cursor = 'default';
            row.style.backgroundColor = 'transparent';
        });
    });

    function viewFullCV(cvId) {
        window.location.href = 'view?id=' + cvId;
    }
});