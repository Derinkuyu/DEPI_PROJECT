import { getDeviceToken } from '/js/Firebase/notification.js';


console.log("this script is a test, Hello World!");

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

    //const errorArea = document.getElementById('errorArea');
    loginBtnTxt.textContent = "Checking";
    loginSpinner.classList.remove('hidden');
    loginButton.classList.add("btn-disabled");

    $(`#login-error`).attr(`hidden`,`hidden`);

    const deviceToken = await getDeviceToken();
    console.log("Device Token:", deviceToken);

    try {
        const response = await fetch('/api/auth/login', {
            method: 'POST',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify(
                {
                    email: email,
                    password: pass,
                    deviceToken: deviceToken
                })
        });

        const result = await response.json();

        if (response.ok) {
            console.log("Login success")
            window.location.href = '/';

        } else {
            console.log("Login failed")
            $(`#login-error`).removeAttr(`hidden`);
            $(`#login-error`).text(function (index) {
                return result.message;
            });
        }

        console.log(result.message)

    } catch (err) {
        console.log("Error happened during login.\n" + err)
        $(`#login-error`).removeAttr(`hidden`);
        $(`#login-error`).text(function (index) {
            return `Internal Error. Please try again later.`;
        });
    }
    loginBtnTxt.textContent = "Sign in";
    loginSpinner.classList.add('hidden');
    loginButton.classList.remove("btn-disabled");
}