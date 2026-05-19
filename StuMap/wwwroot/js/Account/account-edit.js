const $password = $(`#newpassword`);
const $confirmPassword = $(`#confirmPassword`);

//#region Get Countries

const $country = $('#country');
if ($country.length > 0) {
    $.ajax({
        url: 'https://restcountries.com/v3.1/all?fields=name,cca2',
        method: 'GET',
        success: function (countries) {

            // Sort countries alphabetically by common name
            countries.sort((a, b) => a.name.common.localeCompare(b.name.common));

            const accountCountry = $(`#acc-country`).val();
            // Append each country to the dropdown
            countries.forEach(country => {
                if (country.name.common != accountCountry)
                    $country.append(`<option value="${country.name.common}">${country.name.common}</option>`);
            });
        },
        error: function () {
            console.error("Failed to load country list.");
        }
    });
}
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

$($password).on('input', function () {
    const value = $(this).val();

    const rules = {
        length: value.length >= 8,
        uppercase: /[A-Z]/.test(value),
        lowercase: /[a-z]/.test(value),
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
    updateRequirementUi('req-lowercase', rules.lowercase);
    updateRequirementUi('req-number', rules.number);

    if (rules.length && rules.uppercase && rules.number && rules.lowercase) {
        this.setCustomValidity("");
    } else {
        this.setCustomValidity("Password does not meet requirements");
    }
});
//#endregion


