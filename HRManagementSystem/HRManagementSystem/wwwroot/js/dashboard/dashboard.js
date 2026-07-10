(function () {
  const primary = '#0057cd';
  const tertiary = '#00677c';
  const success = '#198754';
  const warning = '#f59e0b';

  // Employee Growth
  const g = document.getElementById('growthChart');
  if (g && window.Chart) {
    const ctx = g.getContext('2d');
    const grad = ctx.createLinearGradient(0, 0, 0, 260);
    grad.addColorStop(0, 'rgba(0,87,205,0.28)');
    grad.addColorStop(1, 'rgba(0,87,205,0)');
    new Chart(ctx, {
      type: 'line',
      data: {
        labels: ['Oct', 'Nov', 'Dec', 'Jan', 'Feb', 'Mar', 'Apr', 'May', 'Jun', 'Jul'],
        datasets: [{
          label: 'Employees',
          data: [1150, 1162, 1175, 1183, 1195, 1205, 1218, 1229, 1240, 1248],
          borderColor: primary,
          backgroundColor: grad,
          fill: true,
          tension: 0.35,
          borderWidth: 2.5,
          pointRadius: 3,
          pointBackgroundColor: '#fff',
          pointBorderColor: primary,
          pointBorderWidth: 2
        }]
      },
      options: {
        responsive: true,
        maintainAspectRatio: false,
        plugins: { legend: { display: false } },
        scales: {
          y: { beginAtZero: false, grid: { color: '#eef1f6' }, ticks: { color: '#6b7280' } },
          x: { grid: { display: false }, ticks: { color: '#6b7280' } }
        }
      }
    });
  }

  // Recruitment Pipeline
  const p = document.getElementById('pipelineChart');
  if (p && window.Chart) {
    new Chart(p.getContext('2d'), {
      type: 'doughnut',
      data: {
        labels: ['Sourced', 'Interview', 'Offer', 'Hired'],
        datasets: [{
          data: [85, 35, 12, 10],
          backgroundColor: [primary, tertiary, warning, success],
          borderWidth: 0,
          hoverOffset: 6
        }]
      },
      options: {
        responsive: true,
        maintainAspectRatio: false,
        cutout: '65%',
        plugins: {
          legend: { position: 'bottom', labels: { color: '#374151', boxWidth: 12, padding: 12 } }
        }
      }
    });
  }
})();