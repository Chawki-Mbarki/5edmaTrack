const loginForm = document.querySelector(".login-form-box");
const registerForm = document.querySelector(".register-form-box");
const veil = document.querySelector(".veil");

veil.addEventListener("click", () => {
    if (!registerForm.classList.contains("hide")) {
        toggleVisibility(registerForm);
    }
    if (!loginForm.classList.contains("hide")) {
        toggleVisibility(loginForm);
    }
});

document.querySelector(".login-form-box .fa-xmark").addEventListener("click", () => {
    toggleVisibility(loginForm);
});

document.querySelector(".login-btn").addEventListener("click", () => {
    toggleVisibility(loginForm);
});

document.querySelector(".log-in-link").addEventListener("click", () => {
    toggleVisibility(loginForm);
});

document.querySelector(".register-form-box .fa-xmark").addEventListener("click", () => {
    toggleVisibility(registerForm);
});

document.querySelectorAll(".sign-up-link").forEach(element => {
    element.addEventListener("click", () => {
        toggleVisibility(registerForm);
    });
});

function toggleVisibility(target) {
    const isHidden = target.classList.contains('hide');
    
    document.querySelectorAll(".visible").forEach(ele => {
        ele.classList.remove('visible');
        ele.classList.add('hide');
    });


    target.classList.toggle('hide', !isHidden);
    target.classList.toggle('visible', isHidden);
    veil.classList.toggle('hide', !isHidden);
    
    console.log("Is it hidden?:", !isHidden);
}
