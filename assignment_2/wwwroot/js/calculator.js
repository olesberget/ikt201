display = document.getElementById("display")
function entry(num){display.value += num}
function calculate() {
    display.value = display.value.replace(/(\++)/g, '+');
    display.value = display.value.replace(/(\--)/g, '-');
    display.value = display.value.replace(/\*\*/g, '*');
    display.value = display.value.replace(/\/\//g, '/');
    display.value = eval(display.value);
}
function C(){display.value = '';}
function CE(){display.value = display.value.substring(0, display.value.length-1);}
function pros() {
    try {
        inputValue = parseFloat(display.value);
        display.value = (inputValue / 100).toString();
    } catch (err) {
        alert("Invalid");
    }
}