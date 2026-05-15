document.addEventListener('DOMContentLoaded', function () {

    const myForm = document.getElementById('loginForm');

    myForm.addEventListener('submit', async function (event) {
        event.preventDefault();
        await performLogin();
    });
});

async function performLogin() {
    const email = document.getElementById('email').value;
    const pass = document.getElementById('password').value;
    const loginButton = document.getElementById('btnLogin');
    const loginSpinner = document.getElementById('loginSpinner');
    const loginBtnTxt = document.getElementById('loginBtnTxt');

    loginBtnTxt.textContent = "Checking";
    loginSpinner.classList.remove('hidden');
    loginButton.classList.add("btn-disabled");


    try {
        const response = await fetch('/api/auth/login', {
            method: 'POST',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify(
                {
                    email: email,
                    password: pass
                })
        });

        const result = await response.json();

        if (response.ok && result.success) {
            console.log("Login success")
        } else {
            console.log("Login failed")
        }
    } catch (err) {
        console.log("Error happened during login.\n" + err)
    }
    loginBtnTxt.textContent = "Sign in";
    loginSpinner.classList.add('hidden');
    loginButton.classList.remove("btn-disabled");
}