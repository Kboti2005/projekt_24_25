function register() {
    var nev = document.getElementById("nev").value;
    var email = document.getElementById("email").value;
    var password = document.getElementById("password").value;
    var passwordRepeat = document.getElementById("passwordRepeat").value;
    if (nev != "" &&email != "" &&password != "" &&passwordRepeat != "" && password == passwordRepeat) {
      alert("Köszönjük a regisztrációt!")  
    }
    if (password != passwordRepeat) alert("A jelszavak nem egyeznek!")
    else alert("Tölts ki minden mezőt!")
}