let result = document.getElementById('result');
let resultBox = document.getElementById('result-box');
let countInput = document.getElementById('count');
let alertsBox = document.getElementById('alerts-box');
document.getElementById('btn-show-result').clientWidth = countInput.clientWidth;
const showNumber = () => {
    if (checkNumber(Number.parseInt(countInput.value)) == true) {
        if (alertsBox.classList.contains('d-none')) {
            // do nothing
        }
        else {
            alertsBox.classList.add('d-none');
        }
        if (resultBox.classList.contains('d-none')) {
            resultBox.classList.remove('d-none');
        }
        result.innerHTML = getRandomNumber(Number.parseInt(countInput.value));

    }
    else {
        alertsBox.classList.remove('d-none');
        resultBox.classList.add('d-none');
        alertsBox.innerHTML = '<div class="alert alert-danger">Please enter a valid and positive number</div>';
    }
};
const checkNumber = (number) => {
    if (number <= 0) {
        return false;
    }
    else {
        return true;
    }
};

const getRandomNumber = (count) => {
    if (isNaN(count)) {
        count = Number.parseInt(count);
    }
    let random_number = Math.floor((Math.random() * count) + 1);
    while (random_number === count + 1) {
        random_number = Math.floor((Math.random() * count) + 1);
    }
    return random_number;
};
