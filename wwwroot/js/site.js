let mouseMovements = [];

document.addEventListener('mousemove', (event) => {
    const pointX = event.clientX;
    const pointY = event.clientY;
    const now = new Date();
    const time = now.getFullYear() + "-" +
        String(now.getMonth() + 1).padStart(2, '0') + "-" +
        String(now.getDate()).padStart(2, '0') + " " +
        String(now.getHours()).padStart(2, '0') + ":" +
        String(now.getMinutes()).padStart(2, '0') + ":" +
        String(now.getSeconds()).padStart(2, '0') + "." +
        String(now.getMilliseconds()).padStart(3, '0');



    mouseMovements.push({ pointX, pointY, time });
});

document.getElementById('mouseForm').addEventListener('submit', function (event) {
    event.preventDefault(); 

    const json = JSON.stringify(mouseMovements);

    const input = document.createElement('input');
    input.type = 'hidden';
    input.name = 'jsonData';
    input.value = json;

    event.target.appendChild(input);

    event.target.submit();
});