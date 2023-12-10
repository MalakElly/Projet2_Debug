// Write your JavaScript code.
function validateForm() {
    var name = document.getElementById("Name").value;
    var address = document.getElementById("Address").value;
    var city = document.getElementById("City").value;
    var country = document.getElementById("Country").value;

    if (name === "" || address === "" || city === "" || country === "") {
        alert("Veuillez renseigner tous les champs marqués d'une étoile.");
        return false;
    }

    return true;
}