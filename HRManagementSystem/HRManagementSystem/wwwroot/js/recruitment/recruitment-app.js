document.addEventListener('DOMContentLoaded', function() {

    const trendCtx = document.getElementById('applicationsTrendChart');
    if (trendCtx) {
        new Chart(trendCtx.getContext('2d'), {
            type: 'line',
            data: {
                labels: ['Mon', 'Tue', 'Wed', 'Thu', 'Fri', 'Sat', 'Sun'],
                datasets: [{
                    label: 'Applications',
                    data: [65, 59, 80, 81, 56, 40, 45],
                    borderColor: '#0057cd',
                    backgroundColor: 'rgba(0, 87, 205, 0.06)',
                    fill: true,
                    tension: 0.4,
                    borderWidth: 2,
                    pointRadius: 3,
                    pointBackgroundColor: '#0057cd'
                }]
            },
            options: {
                responsive: true,
                maintainAspectRatio: false,
                plugins: { legend: { display: false } },
                scales: {
                    y: { display: false, beginAtZero: true },
                    x: { grid: { display: false }, ticks: { font: { size: 10 } } }
                }
            }
        });
    }

    const funnelCtx = document.getElementById('hiringFunnelChart');
    if (funnelCtx) {
        new Chart(funnelCtx.getContext('2d'), {
            type: 'bar',
            data: {
                labels: ['Applied', 'Screening', 'Interview', 'Offer'],
                datasets: [{
                    data: [450, 120, 45, 18],
                    backgroundColor: ['#d8e1ea', '#bfc8d0', '#575f67', '#0057cd'],
                    borderRadius: 4,
                    barThickness: 20
                }]
            },
            options: {
                indexAxis: 'y',
                responsive: true,
                maintainAspectRatio: false,
                plugins: { legend: { display: false } },
                scales: {
                    x: { display: false },
                    y: { grid: { display: false }, ticks: { font: { size: 11, weight: '600' } } }
                }
            }
        });
    }

    // Candidate cards give a lightweight preview action (kept in-page since candidates
    // aren't part of the Employees/Departments directories).
    document.querySelectorAll('.kanban-card[data-target]').forEach((card) => {
        card.addEventListener('click', () => {
            alert(`Opening candidate profile for: ${card.dataset.target}`);
        });
    });
});
