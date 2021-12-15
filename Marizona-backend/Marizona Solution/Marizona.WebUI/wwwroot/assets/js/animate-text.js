const position = document.querySelector('.text-animation');

position.addEventListener('mousemove', e => {
    position.style.setProperty('--x', e.clientX + 'px');
})