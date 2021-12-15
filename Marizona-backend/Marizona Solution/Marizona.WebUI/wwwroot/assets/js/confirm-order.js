const nameInput = document.getElementById("name");
const surnameInput = document.getElementById("surname");
const telephoneInput = document.getElementById("telephone");
const addressInput = document.getElementById("address");


const nameError = document.querySelector(".name-error");
const surnameError = document.querySelector(".surname-error");
const phoneError = document.querySelector(".phone-error");
const addressError = document.querySelector(".address-error");

const submit = document.querySelector("#confirm-btn");

submit.addEventListener('click', (e) => {
    e.preventDefault();
    const valueLengthName = nameInput.value.length;
    const valueLengthSurname = surnameInput.value.length;
    const valueLengthPhone = telephoneInput.value.length;
    const valueLengthAddress = addressInput.value.length;

    
    if (valueLengthName == 0) {
        nameError.classList.add("error");
    }
    else{
        nameError.classList.remove("error");
    }

    if (valueLengthSurname == 0) {
        surnameError.classList.add("error");
    }
    else{
        surnameError.classList.remove("error");
    }

    if (valueLengthPhone == 0) {
        phoneError.classList.add("error");
    }
    else{
        phoneError.classList.remove("error");
    }

    if (valueLengthAddress == 0) {
        addressError.classList.add("error");
    }
    else{
        addressError.classList.remove("error");
    }
})

