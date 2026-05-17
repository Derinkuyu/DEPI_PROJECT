const $accountTypeForm = $(`#form-1`);
const $registerForm = $(`#form-2`);
const $password = $(`#password`);
const $confirmPassword = $(`#confirmPassword`);

let currentForm = 1;


$($accountTypeForm).on('submit', async function (event) {
    event.preventDefault();

    const formData = new FormData($($accountTypeForm)[0])
    const data = Object.fromEntries(formData.entries());

    await showRegisterationForm(data["account-type"]);
});


$($registerForm).on('submit', async function (event) {
    event.preventDefault();
    signup();
});


//#region Max date of birth
const today = new Date();
// todo: how old can the users be?
const maxYear = today.getFullYear() - 3;
const month = String(today.getMonth() + 1).padStart(2, '0'); // Months are 0-indexed
const day = String(today.getDate()).padStart(2, '0');

const maxDateString = `${maxYear}-${month}-${day}`;

$('#birthdate').attr('max', maxDateString);
//#endregion

//#region Get Countries
$.ajax({
    url: 'https://restcountries.com/v3.1/all?fields=name,cca2',
    method: 'GET',
    success: function (countries) {
        const $select = $('#country');

        // Sort countries alphabetically by common name
        countries.sort((a, b) => a.name.common.localeCompare(b.name.common));

        // Append each country to the dropdown
        countries.forEach(country => {
            $select.append(`<option value="${country.cca2}">${country.name.common}</option>`);
        });
    },
    error: function () {
        console.error("Failed to load country list.");
    }
});
//#endregion


//#region Password Validation
$password.on('input', checkPasswordMatch);
$confirmPassword.on('input', checkPasswordMatch);

function checkPasswordMatch() {
    const passVal = $password.val();
    const confirmVal = $confirmPassword.val();


    if (passVal !== confirmVal && confirmVal.length > 0) {
        // Tell the browser native validation engine it's broken
        $confirmPassword[0].setCustomValidity("Passwords do not match");
    }
    else {
        $confirmPassword[0].setCustomValidity("");
    }
}

$('#password').on('input', function () {
    const value = $(this).val();

    const rules = {
        length: value.length >= 8,
        uppercase: /[A-Z]/.test(value),
        number: /[0-9]/.test(value),
    };
    function updateRequirementUi(elementId, isPassed) {
        const $el = $(`#${elementId}`);
        const $icon = $el.find('.status-icon');

        if (isPassed) {
            $el.removeClass('text-gray-500 text-red-500').addClass('text-green-600 font-medium');
            $icon.text('✅');
        } else {
            if (value.length === 0) {
                $el.removeClass('text-green-600 text-red-500').addClass('text-gray-500');
            } else {
                $el.removeClass('text-gray-500 text-green-600').addClass('text-red-500');
            }
            $icon.text('❌');
        }
    }
    updateRequirementUi('req-length', rules.length);
    updateRequirementUi('req-uppercase', rules.uppercase);
    updateRequirementUi('req-number', rules.number);

    if (rules.length && rules.uppercase && rules.number) {
        this.setCustomValidity("");
    } else {
        this.setCustomValidity("Password does not meet requirements");
    }
});
//#endregion



//#region Sign Up
async function signup() {
    const accType = Object.fromEntries(new FormData($accountTypeForm[0]));

    if (accType[`account-type`] == `Contributor` && $(`.certificate-item`).length == 0) {
        alert(`You need to add at least one certificate`);
        return;
    }
    const $buttons = $(`.btn:not([disabled])`);
    $buttons.attr(`disabled`, `disabled`);

    try {


        const formFields = Object.fromEntries(new FormData($registerForm[0]));
        const extraData = {
            AccountType: accType[`account-type`],
            FormSubmittedAt: new Date().toISOString(),
        };
        let completePayload = {
            ...extraData,
            ...formFields,
        };


        var certificates = [];
        $('.certificate-item').each(function () {
            var $item = $(this);

            certificates.push({
                title: $item.find('.certificate-title').val(),
                url: $item.find('.certificate-url').val(),
            });
        });
        completePayload.certificates = certificates;

        console.log(completePayload);
        console.log('Created signup payload');

        console.log('sending request');
        const response = await fetch('/api/auth/signup', {
            method: 'POST',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify(completePayload)
        });

        console.log('recieved response');

        if (response.ok) {
            const result = await response.json();
            if (result.success) {
                console.log("signup success")

                $('#signup-modal')[0].showModal();
            }
            else {
                //this should never happen
                console.log("WHAAAAAAAAAAAAAAAT?")
            }
        } else {
            console.log("signup failed")
        }
    } catch (err) {
        console.log("Error happened during signup.\n" + err)
    }

    $buttons.removeAttr(`disabled`);

}
//#endregion

function gotoLogin() {
    window.location.href = '/Login';
}



async function showRegisterationForm(accountType) {
    const formData = new FormData($($accountTypeForm)[0])
    const data = Object.fromEntries(formData.entries());
    console.log(data);

    goToForm(2);

    if (accountType === "Student") {
        $(`#certificates-field`).attr(`hidden`, `hidden`);
        $(`#certificates-field`).attr(`disabled`, `disabled`);
    }
    else if (accountType === "Contributor") {
        $(`#certificates-field`).removeAttr(`hidden`);
        $(`#certificates-field`).removeAttr(`disabled`);
    }
}

function goToForm(form) {

    const $currentForm = $(`[data-form="${currentForm}"]`);
    const $targetForm = $(`[data-form="${form}"]`);

    if ($targetForm.length === 0) return;

    //console.log(`current form = ${currentForm}\nnext form = ${form}`)
    const $buttons = $(`.btn:not([disabled])`);
    $buttons.attr(`disabled`, `disabled`);


    const exitClass = form > currentForm ? '-translate-x-5' : 'translate-x-5';
    const enterClass = form > currentForm ? 'translate-x-5' : '-translate-x-5';

    $currentForm
        .removeClass('opacity-100 translate-x-0')
        .addClass(`opacity-0 ${exitClass}`);

    setTimeout(() => {
        $currentForm.addClass('hidden').removeClass(exitClass);

        $targetForm
            .removeClass('hidden')
            .addClass(`opacity-0 ${enterClass}`);

        setTimeout(() => {
            $targetForm
                .removeClass(`opacity-0 ${enterClass}`)
                .addClass('opacity-100 translate-x-0');

            $buttons.removeAttr(`disabled`);

        }, 20);

        currentForm = form;

    }, 300);
}

let cert = 1;
function addCertificate() {

    if ($(`.certificate-item`).length >= 8) {
        alert(`Maximum number of certificates reached`);
        return;
    }

    var templateContent = $('#certificate-template').html();
    var $clone = $(templateContent);
    $clone.attr('data-certificate', cert);

    $clone.find('.certificate-title').on('input', function () {
        const newTitle = $(this).val();
        const $title = $($clone).find(`.collapse-title`);
        if ($(this).val().length == 0) {
            $($title).text(function (index) {
                return "New Certificate";
            })
        }
        else {
            $($title).text(function (index) {
                return newTitle;
            })
        }
    });

    $clone.find('.delete-certificate').attr('data-certificate', cert).on('click', function () {
        $clone.remove();
    });

    $('#certificate-list').append($clone);

    cert += 1;
}
function removeCertificate(certificate) {

    var templateContent = $('#certificate-template').html();
    var $clone = $(templateContent);
    $clone.attr('data-certificate', cert);
    $clone.find('.delete-certificate').attr('data-certificate', cert);

    $('#certificate-list').append($clone);

    cert += 1;
}