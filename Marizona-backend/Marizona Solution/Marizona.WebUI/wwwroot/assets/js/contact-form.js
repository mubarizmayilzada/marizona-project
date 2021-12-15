const inputName = document.getElementById("name");
const inputEmail = document.getElementById("email");
const inputSubject = document.getElementById("subject");
const inputTextarea = document.getElementById("textarea");

const smallName = document.getElementById("nameSmall");
const smallEmail = document.getElementById("emailSmall");
const smallSubject = document.getElementById("emailSubject");
const smallComment = document.getElementById("emailComment");
const submitBtn = document.getElementById("submit");
const formControlName = document.getElementById("form-control-name");
const formControlEmail = document.getElementById("form-control-email");
const formControlSubject = document.getElementById("form-control-subject");
const formControlComment = document.getElementById("form-control-comment");

function checkEmail(input) {
    const re = /^(([^<>()[\]\\.,;:\s@"]+(\.[^<>()[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
    if(re.test(input.value.trim())){
        formControlEmail.classList.add("success");
    }
    else if (input.value.length == 0) {
        smallEmail.innerText = "Email bosh qoyula bilmez";
        formControlEmail.classList.remove("success");
        formControlEmail.classList.add("error");
    }
    else{
        smallEmail.innerText = "Email duz deyil qaqash";
        formControlEmail.classList.remove("success");
        formControlEmail.classList.add("error");
    }
}

submitBtn.addEventListener("click", (e) => {
    e.preventDefault();

    checkEmail(inputEmail);


    const valueLength = inputName.value.length;

    if (valueLength > 3) {
        formControlName.classList.remove("error");
        formControlName.classList.add("success");
    }
    else{
        formControlName.classList.remove("success");
        formControlName.classList.add("error")
    }




    const valueLengthSubject = inputSubject.value.length;

    if (valueLengthSubject > 5) {
        formControlSubject.classList.remove("error");
        formControlSubject.classList.add("success");
    }
    else{
        formControlSubject.classList.remove("success");
        formControlSubject.classList.add("error")
    }
})