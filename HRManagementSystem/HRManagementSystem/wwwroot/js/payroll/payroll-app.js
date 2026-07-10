document.addEventListener("DOMContentLoaded", function () {
  const primary = "#0057cd";
  const border = "#e6e9ef";
  const muted = "#9aa2b1";

  // Payroll cost trend
  const trendEl = document.getElementById("payrollTrendChart");
  if (trendEl && window.Chart) {
    const ctx = trendEl.getContext("2d");
    const grad = ctx.createLinearGradient(0, 0, 0, 250);
    grad.addColorStop(0, "rgba(0,87,205,0.25)");
    grad.addColorStop(1, "rgba(0,87,205,0)");
    new Chart(ctx, {
      type: "line",
      data: {
        labels: ["Feb", "Mar", "Apr", "May", "Jun", "Jul"],
        datasets: [
          {
            label: "Total payroll ($)",
            data: [1720000, 1745000, 1768000, 1790000, 1822000, 1860000],
            borderColor: primary,
            backgroundColor: grad,
            fill: true,
            tension: 0.35,
            borderWidth: 2.5,
            pointRadius: 3,
            pointBackgroundColor: "#fff",
            pointBorderColor: primary,
            pointBorderWidth: 2,
          },
        ],
      },
      options: {
        responsive: true,
        maintainAspectRatio: false,
        plugins: { legend: { display: false } },
        scales: {
          y: {
            beginAtZero: false,
            grid: { color: border },
            ticks: { color: muted, callback: (v) => `$${(v / 1000000).toFixed(1)}M` },
          },
          x: { grid: { display: false }, ticks: { color: muted } },
        },
      },
    });
  }

  // Salary distribution by department
  const distData = [
    { label: "Engineering", value: 720000, color: "#0057cd" },
    { label: "Sales", value: 410000, color: "#00677c" },
    { label: "Marketing", value: 260000, color: "#f59e0b" },
    { label: "Finance", value: 210000, color: "#575f67" },
    { label: "HR & Ops", value: 160000, color: "#198754" },
    { label: "Product Design", value: 100000, color: "#dc3545" },
  ];
  const distEl = document.getElementById("salaryDistChart");
  if (distEl && window.Chart) {
    new Chart(distEl.getContext("2d"), {
      type: "bar",
      data: {
        labels: distData.map((d) => d.label),
        datasets: [{ data: distData.map((d) => d.value), backgroundColor: distData.map((d) => d.color), borderRadius: 3, barThickness: 16 }],
      },
      options: {
        indexAxis: "y",
        responsive: true,
        maintainAspectRatio: false,
        plugins: { legend: { display: false } },
        scales: {
          x: { display: false },
          y: { grid: { display: false }, ticks: { color: "#374151", font: { size: 11, weight: "600" } } },
        },
      },
    });
  }

  // Payroll register
  const payroll = [
    { name: "Robert Fox", dept: "Engineering", base: 10416, allowances: 800, deductions: 1560, avatar: "https://images.unsplash.com/photo-1534528741775-53994a69daeb?w=100&auto=format&fit=crop&q=60", status: "Paid" },
    { name: "Jane Cooper", dept: "Engineering", base: 9583, allowances: 600, deductions: 1420, avatar: "https://images.unsplash.com/photo-1494790108377-be9c29b29330?w=100&auto=format&fit=crop&q=60", status: "Paid" },
    { name: "Kristin Watson", dept: "Marketing", base: 11250, allowances: 750, deductions: 1680, avatar: "https://images.unsplash.com/photo-1438761681033-6461ffad8d80?w=100&auto=format&fit=crop&q=60", status: "Paid" },
    { name: "David Kim", dept: "Finance", base: 8750, allowances: 400, deductions: 1310, avatar: "https://images.unsplash.com/photo-1560250097-0b93528c311a?w=100&auto=format&fit=crop&q=60", status: "Pending" },
    { name: "Guy Hawkins", dept: "Sales", base: 9166, allowances: 1200, deductions: 1450, avatar: "https://images.unsplash.com/photo-1500648767791-00dcc994a43e?w=100&auto=format&fit=crop&q=60", status: "Paid" },
    { name: "Arlene McCoy", dept: "HR & Ops", base: 8333, allowances: 350, deductions: 1210, avatar: "https://images.unsplash.com/photo-1487412720507-e7ab37603c6f?w=100&auto=format&fit=crop&q=60", status: "Pending" },
    { name: "Jacob Jones", dept: "Product Design", base: 9000, allowances: 500, deductions: 1330, avatar: "https://images.unsplash.com/photo-1507003211169-0a1dd7228f2d?w=100&auto=format&fit=crop&q=60", status: "Failed" },
  ];

  const statusChip = (s) => ({ Paid: "chip-success", Pending: "chip-warning", Failed: "chip-danger" }[s] || "chip-primary");
  const fmt = (n) => `$${n.toLocaleString("en-US")}`;

  document.getElementById("payrollBody").innerHTML = payroll
    .map((p) => {
      const net = p.base + p.allowances - p.deductions;
      return `
      <tr>
        <td class="ps-3">
          <div class="emp">
            <img class="row-avatar" src="${p.avatar}" alt="${p.name}">
            <div>
              <div class="fw-semibold" style="color:var(--text)">${p.name}</div>
              <div class="text-muted small">${p.dept}</div>
            </div>
          </div>
        </td>
        <td class="text-muted">Jul 2026</td>
        <td>${fmt(p.base)}</td>
        <td class="text-success">+${fmt(p.allowances)}</td>
        <td class="text-danger">-${fmt(p.deductions)}</td>
        <td class="fw-semibold" style="color:var(--text)">${fmt(net)}</td>
        <td class="pe-3"><span class="chip ${statusChip(p.status)}">${p.status}</span></td>
      </tr>`;
    })
    .join("");
});
