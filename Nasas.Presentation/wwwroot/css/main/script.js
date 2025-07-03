const centerX = 400; // Центр контейнера (800 / 2)
const centerY = 400;

document.querySelectorAll(".planet").forEach((planet) => {
  const radius = parseInt(planet.getAttribute("data-radius"), 10);
  const angle = Math.random() * 2 * Math.PI;

  const planetSize = planet.offsetWidth;
  const x = centerX + radius * Math.cos(angle) - planetSize / 2;
  const y = centerY + radius * Math.sin(angle) - planetSize / 2;

  planet.style.left = `${x}px`;
  planet.style.top = `${y}px`;
});
