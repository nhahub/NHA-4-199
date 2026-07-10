document.addEventListener("DOMContentLoaded", function () {
  const history = [
    { date: "2026-07-08", checkIn: "08:55 AM", checkOut: "05:50 PM", hours: "8h 55m", status: "On Time" },
    { date: "2026-07-07", checkIn: "09:18 AM", checkOut: "06:05 PM", hours: "8h 47m", status: "Late" },
    { date: "2026-07-06", checkIn: "—", checkOut: "—", hours: "—", status: "On Leave" },
    { date: "2026-07-03", checkIn: "08:49 AM", checkOut: "05:40 PM", hours: "8h 51m", status: "On Time" },
    { date: "2026-07-02", checkIn: "08:52 AM", checkOut: "05:47 PM", hours: "8h 55m", status: "On Time" },
    { date: "2026-07-01", checkIn: "08:56 AM", checkOut: "05:52 PM", hours: "8h 56m", status: "On Time" },
  ];

  const statusClass = (s) =>
    ({
      "On Time": "status-on-time",
      Late: "status-late",
      "Half Day": "status-halfday",
      Absent: "chip-danger",
      "On Leave": "chip-primary",
    }[s] || "chip-primary");

  function formatDate(iso) {
    return new Date(iso + "T00:00:00").toLocaleDateString("en-US", { weekday: "short", month: "short", day: "numeric" });
  }

  const body = document.getElementById("myAttBody");
  body.innerHTML = history
    .map((h) => {
      const isPill = h.status === "On Leave" || h.status === "Absent";
      const badge = isPill
        ? `<span class="chip ${statusClass(h.status)}">${h.status}</span>`
        : `<span class="badge-status ${statusClass(h.status)}">${h.status}</span>`;
      return `
      <tr>
        <td class="ps-3 fw-medium">${formatDate(h.date)}</td>
        <td class="text-muted">${h.checkIn}</td>
        <td class="text-muted">${h.checkOut}</td>
        <td>${h.hours}</td>
        <td class="pe-3">${badge}</td>
      </tr>`;
    })
    .join("");

  // Live clock
  const clockEl = document.getElementById("liveClock");
  const dateEl = document.getElementById("todayDate");
  function tick() {
    const now = new Date();
    clockEl.textContent = now.toLocaleTimeString("en-US", { hour: "2-digit", minute: "2-digit", second: "2-digit" });
    dateEl.textContent = now.toLocaleDateString("en-US", { weekday: "long", month: "long", day: "numeric", year: "numeric" });
  }
  tick();
  setInterval(tick, 1000);

  // Check in / out flow
  const checkInBtn = document.getElementById("checkInBtn");
  const checkOutBtn = document.getElementById("checkOutBtn");
  const punchIn = document.getElementById("punchInVal");
  const punchOut = document.getElementById("punchOutVal");
  const statusBadge = document.getElementById("todayStatus");

  function nowTime() {
    return new Date().toLocaleTimeString("en-US", { hour: "2-digit", minute: "2-digit" });
  }

  function setStatus(label, cls) {
    statusBadge.textContent = label;
    statusBadge.className = `badge-status ${cls}`;
    statusBadge.style.fontSize = "11px";
  }

  checkInBtn.addEventListener("click", () => {
    const time = nowTime();
    punchIn.textContent = time;
    const isLate = new Date().getHours() >= 9 && new Date().getMinutes() > 15;
    setStatus(isLate ? "Late" : "On Time", isLate ? "status-late" : "status-on-time");
    checkInBtn.disabled = true;
    checkOutBtn.disabled = false;
    alert(`Checked in at ${time}.`);
  });

  checkOutBtn.addEventListener("click", () => {
    const time = nowTime();
    punchOut.textContent = time;
    checkOutBtn.disabled = true;
    alert(`Checked out at ${time}. Have a good evening!`);
  });
});
