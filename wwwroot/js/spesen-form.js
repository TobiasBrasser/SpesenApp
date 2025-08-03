document.addEventListener("DOMContentLoaded", function () {
    const kmInput = document.getElementById("KmAuto");
    const autoField = document.getElementById("ReisespesenAuto");

    function updateAutoSpesen() {
        const km = parseFloat(kmInput.value) || 0;
        autoField.value = (km * 0.7).toFixed(2);
    }

    if (kmInput && autoField) {
        kmInput.addEventListener("input", updateAutoSpesen);
        updateAutoSpesen(); // initial
    }
});
