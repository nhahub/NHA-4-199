document.addEventListener("DOMContentLoaded", function () {
  const primary = "#0057cd";
  const tertiary = "#00677c";
  const danger = "#dc3545";
  const secondary = "#575f67";
  const warning = "#f59e0b";
  const border = "#e6e9ef";
  const muted = "#9aa2b1";

  // Leave usage trend
  const usageEl = document.getElementById("leaveUsageChart");
  if (usageEl && window.Chart) {
    new Chart(usageEl.getContext("2d"), {
      type: "bar",
      data: {
        labels: ["Feb", "Mar", "Apr", "May", "Jun", "Jul"],
        datasets: [{ label: "Leave days taken", data: [142, 118, 96, 134, 210, 88], backgroundColor: primary, borderRadius: 3, barThickness: 30 }],
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

  // Leave type distribution
  const typeData = [
    { label: "Annual", value: 46, color: primary },
    { label: "Sick", value: 24, color: danger },
    { label: "Casual", value: 16, color: tertiary },
    { label: "Unpaid", value: 8, color: secondary },
    { label: "Parental", value: 6, color: warning },
  ];
  const typeEl = document.getElementById("leaveTypeChart");
  if (typeEl && window.Chart) {
    new Chart(typeEl.getContext("2d"), {
      type: "doughnut",
      data: {
        labels: typeData.map((t) => t.label),
        datasets: [{ data: typeData.map((t) => t.value), backgroundColor: typeData.map((t) => t.color), borderWidth: 0, hoverOffset: 4 }],
      },
      options: {
        responsive: true,
        maintainAspectRatio: false,
        cutout: "68%",
        plugins: { legend: { display: false } },
      },
    });
  }
  document.getElementById("leaveTypeLegend").innerHTML = typeData
    .map(
      (t) => `
    <div class="legend-row">
      <span class="legend-key"><span class="legend-dot" style="background:${t.color}"></span>${t.label}</span>
      <span class="legend-val">${t.value}%</span>
    </div>`
    )
    .join("");

  // Recent requests
  const requests = [
    { name: "Sarah Jenkins", dept: "Marketing", type: "Annual", typeCls: "leave-annual", dates: "Jul 12 - Jul 14, 2026", status: "Pending" },
    { name: "David Kim", dept: "Finance", type: "Sick", typeCls: "leave-sick", dates: "Jul 9, 2026", status: "Approved" },
    { name: "Amanda Foster", dept: "HR & Ops", type: "Casual", typeCls: "leave-casual", dates: "Jul 8 - Jul 8, 2026", status: "Approved" },
    { name: "Cody Fisher", dept: "Product Design", type: "Unpaid", typeCls: "leave-unpaid", dates: "Jul 21 - Jul 25, 2026", status: "Pending" },
    { name: "Elena Rodriguez", dept: "Sales", type: "Parental", typeCls: "leave-parental", dates: "Aug 1 - Sep 12, 2026", status: "Rejected" },
  ];

  const statusChip = (s) => ({ Pending: "chip-warning", Approved: "chip-success", Rejected: "chip-danger" }[s] || "chip-primary");

  document.getElementById("leaveOverviewBody").innerHTML = requests
    .map(
      (r) => `
    <tr>
      <td class="ps-3 fw-semibold" style="color:var(--text)">${r.name}</td>
      <td>${r.dept}</td>
      <td><span class="leave-type-pill ${r.typeCls}">${r.type}</span></td>
      <td class="text-muted">${r.dates}</td>
      <td><span class="chip ${statusChip(r.status)}">${r.status}</span></td>
      <td class="text-end pe-3">
        <a href="leave-requests.html" class="btn btn-outline-secondary btn-sm">Review</a>
      </td>
    </tr>`
    )
    .join("");
});
