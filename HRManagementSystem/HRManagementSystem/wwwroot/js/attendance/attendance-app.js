document.addEventListener("DOMContentLoaded", function () {
  const primary = "#0057cd";
  const border = "#e6e9ef";
  const muted = "#9aa2b1";
  const secondary = "#575f67";

  // Attendance Rate (kept to two neutral tones, no rainbow palette)
  const rateEl = document.getElementById("attendanceRateChart");
  if (rateEl && window.Chart) {
    new Chart(rateEl.getContext("2d"), {
      type: "doughnut",
      data: {
        labels: ["Present", "Absent / Leave"],
        datasets: [{ data: [94, 6], backgroundColor: [primary, "#e2e6ee"], borderWidth: 0, hoverOffset: 4 }],
      },
      options: {
        responsive: true,
        maintainAspectRatio: false,
        cutout: "70%",
        plugins: { legend: { position: "bottom", labels: { color: secondary, boxWidth: 10, padding: 12 } } },
      },
    });
  }

  // Late Arrival Trend
  const lateEl = document.getElementById("lateTrendChart");
  if (lateEl && window.Chart) {
    new Chart(lateEl.getContext("2d"), {
      type: "bar",
      data: {
        labels: ["Jul 3", "Jul 4", "Jul 5", "Jul 6", "Jul 7", "Jul 8", "Jul 9"],
        datasets: [{ label: "Late arrivals", data: [22, 30, 18, 26, 41, 24, 38], backgroundColor: primary, borderRadius: 3, barThickness: 26 }],
      },
      options: {
        responsive: true,
        maintainAspectRatio: false,
        plugins: { legend: { display: false } },
        scales: {
          y: { beginAtZero: true, grid: { color: border }, ticks: { color: muted } },
          x: { grid: { display: false }, ticks: { color: muted } },
        },
      },
    });
  }

  const employees = [
    { name: "Sarah Jenkins", dept: "Marketing", checkIn: "08:52 AM", checkOut: "05:45 PM", status: "On Time" },
    { name: "Michael Chang", dept: "Engineering", checkIn: "09:20 AM", checkOut: "06:10 PM", status: "Late" },
    { name: "Elena Rodriguez", dept: "Sales", checkIn: "08:47 AM", checkOut: "05:30 PM", status: "On Time" },
    { name: "David Kim", dept: "Finance", checkIn: "—", checkOut: "—", status: "Absent" },
    { name: "Amanda Foster", dept: "HR & Ops", checkIn: "—", checkOut: "—", status: "On Leave" },
    { name: "Robert Fox", dept: "Engineering", checkIn: "08:58 AM", checkOut: "06:02 PM", status: "On Time" },
    { name: "Jane Cooper", dept: "Engineering", checkIn: "09:32 AM", checkOut: "05:50 PM", status: "Late" },
  ];

  const statusClass = (s) =>
    ({
      "On Time": "status-on-time",
      Late: "status-late",
      Absent: "chip-danger",
      "On Leave": "chip-primary",
    }[s] || "chip-primary");

  const body = document.getElementById("attBody");
  const searchInput = document.getElementById("attSearch");
  const deptFilter = document.getElementById("attDept");
  const statusFilter = document.getElementById("attStatus");

  function render(list) {
    if (!list.length) {
      body.innerHTML = `
        <tr><td colspan="5">
          <div class="empty-state">
            <span class="material-symbols-outlined">groups</span>
            <p>No employees match your filters.</p>
          </div>
        </td></tr>`;
      return;
    }
    body.innerHTML = list
      .map((e) => {
        const isPill = e.status === "Absent" || e.status === "On Leave";
        const badge = isPill
          ? `<span class="chip ${statusClass(e.status)}">${e.status}</span>`
          : `<span class="badge-status ${statusClass(e.status)}">${e.status}</span>`;
        return `
        <tr>
          <td class="ps-4 fw-semibold" style="color:var(--text)">${e.name}</td>
          <td>${e.dept}</td>
          <td class="text-muted">${e.checkIn}</td>
          <td class="text-muted">${e.checkOut}</td>
          <td class="pe-4">${badge}</td>
        </tr>`;
      })
      .join("");
  }

  function applyFilters() {
    const q = searchInput.value.toLowerCase().trim();
    const dept = deptFilter.value;
    const status = statusFilter.value;
    render(
      employees.filter(
        (e) =>
          (!q || e.name.toLowerCase().includes(q)) &&
          (!dept || e.dept === dept) &&
          (!status || e.status === status)
      )
    );
  }

  [searchInput, deptFilter, statusFilter].forEach((el) => el.addEventListener("input", applyFilters));
  render(employees);
});
