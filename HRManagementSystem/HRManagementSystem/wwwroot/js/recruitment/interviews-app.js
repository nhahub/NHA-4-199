document.addEventListener("DOMContentLoaded", function () {
  const interviews = [
    { candidate: "Jack Shephard", position: "DevOps Engineer", round: "Round 2 - Technical", interviewer: "Robert Fox", date: "2026-07-09", time: "14:30", status: "Confirmed" },
    { candidate: "Marcus Wright", position: "Senior Full Stack Developer", round: "Round 1 - Screening", interviewer: "Leslie Alexander", date: "2026-07-10", time: "10:00", status: "Confirmed" },
    { candidate: "Kate Austen", position: "Enterprise Account Executive", round: "Final - Panel", interviewer: "Guy Hawkins", date: "2026-07-13", time: "09:30", status: "Pending" },
    { candidate: "Chloe Sullivan", position: "DevOps Engineer", round: "Round 1 - Screening", interviewer: "Robert Fox", date: "2026-07-13", time: "15:00", status: "Confirmed" },
    { candidate: "Elena Gilbert", position: "Senior Full Stack Developer", round: "Round 2 - Technical", interviewer: "Jane Cooper", date: "2026-07-16", time: "11:00", status: "Confirmed" },
    { candidate: "Sarah Connor", position: "QA Specialist", round: "Round 1 - Screening", interviewer: "Arlene McCoy", date: "2026-07-20", time: "13:00", status: "Cancelled" },
  ];

  const dow = ["Sun", "Mon", "Tue", "Wed", "Thu", "Fri", "Sat"];
  const monthNames = ["January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December"];

  const realToday = new Date();
  let viewYear = realToday.getFullYear();
  let viewMonth = realToday.getMonth();
  let selectedDate = null;

  const calGrid = document.getElementById("calGrid");
  const calMonthLabel = document.getElementById("calMonthLabel");
  const upcomingList = document.getElementById("upcomingList");
  const upcomingSub = document.getElementById("upcomingSub");
  const clearDaySelect = document.getElementById("clearDaySelect");

  const statusBadge = (s) =>
    ({
      Confirmed: "chip-success",
      Pending: "chip-warning",
      Cancelled: "chip-danger",
    }[s] || "chip-primary");

  function isoDate(y, m, d) {
    return `${y}-${String(m + 1).padStart(2, "0")}-${String(d).padStart(2, "0")}`;
  }

  function eventsOn(iso) {
    return interviews.filter((i) => i.date === iso);
  }

  function renderCalendar() {
    calMonthLabel.textContent = `${monthNames[viewMonth]} ${viewYear}`;
    const firstOfMonth = new Date(viewYear, viewMonth, 1);
    const startOffset = firstOfMonth.getDay();
    const daysInMonth = new Date(viewYear, viewMonth + 1, 0).getDate();
    const daysInPrevMonth = new Date(viewYear, viewMonth, 0).getDate();
    const todayIso = isoDate(realToday.getFullYear(), realToday.getMonth(), realToday.getDate());

    const cells = [];
    for (let i = startOffset - 1; i >= 0; i--) {
      cells.push({ day: daysInPrevMonth - i, otherMonth: true });
    }
    for (let d = 1; d <= daysInMonth; d++) {
      cells.push({ day: d, otherMonth: false, iso: isoDate(viewYear, viewMonth, d) });
    }
    while (cells.length % 7 !== 0) {
      cells.push({ day: cells.length - (startOffset + daysInMonth) + 1, otherMonth: true });
    }

    calGrid.innerHTML = cells
      .map((c) => {
        if (c.otherMonth) return `<div class="cal-cell other-month"><span class="cal-day-num">${c.day}</span></div>`;
        const evs = eventsOn(c.iso);
        const classes = [
          "cal-cell",
          c.iso === todayIso ? "today" : "",
          evs.length ? "has-events" : "",
          c.iso === selectedDate ? "selected" : "",
        ]
          .filter(Boolean)
          .join(" ");
        const pills = evs
          .slice(0, 2)
          .map((e) => `<div class="cal-event-pill">${e.time} · ${e.candidate.split(" ")[0]}</div>`)
          .join("");
        const more = evs.length > 2 ? `<div class="cal-event-pill">+${evs.length - 2} more</div>` : "";
        return `<div class="${classes}" data-date="${c.iso}"><span class="cal-day-num">${c.day}</span><div class="cal-events">${pills}${more}</div></div>`;
      })
      .join("");

    calGrid.querySelectorAll(".cal-cell.has-events").forEach((cell) => {
      cell.addEventListener("click", () => {
        selectedDate = selectedDate === cell.dataset.date ? null : cell.dataset.date;
        renderCalendar();
        renderUpcoming();
      });
    });
  }

  function formatDate(iso) {
    return new Date(iso + "T00:00:00").toLocaleDateString("en-US", { weekday: "short", month: "short", day: "numeric" });
  }

  function formatTime(t) {
    const [h, m] = t.split(":").map(Number);
    const period = h >= 12 ? "PM" : "AM";
    const hour = ((h + 11) % 12) + 1;
    return `${hour}:${String(m).padStart(2, "0")} ${period}`;
  }

  function renderUpcoming() {
    let list = interviews.slice().sort((a, b) => (a.date + a.time).localeCompare(b.date + b.time));
    if (selectedDate) {
      list = list.filter((i) => i.date === selectedDate);
      upcomingSub.textContent = `Interviews on ${formatDate(selectedDate)}`;
      clearDaySelect.classList.remove("d-none");
    } else {
      upcomingSub.textContent = "All scheduled interviews";
      clearDaySelect.classList.add("d-none");
    }

    if (!list.length) {
      upcomingList.innerHTML = `
        <div class="empty-state">
          <span class="material-symbols-outlined">event_busy</span>
          <p>No interviews scheduled for this day.</p>
        </div>`;
      return;
    }

    upcomingList.innerHTML = list
      .map(
        (i) => `
      <div class="interview-item">
        <div class="interview-time-badge">${formatDate(i.date)}<br>${formatTime(i.time)}</div>
        <div class="flex-grow-1">
          <div class="d-flex justify-content-between align-items-start">
            <p class="mb-0 fw-semibold small">${i.candidate}</p>
            <span class="chip ${statusBadge(i.status)}">${i.status}</span>
          </div>
          <p class="mb-0 text-muted small">${i.position}</p>
          <p class="mb-0 text-muted" style="font-size: 12px">${i.round} · Interviewer: ${i.interviewer}</p>
        </div>
      </div>`
      )
      .join("");
  }

  document.getElementById("calPrev").addEventListener("click", () => {
    viewMonth -= 1;
    if (viewMonth < 0) { viewMonth = 11; viewYear -= 1; }
    renderCalendar();
  });
  document.getElementById("calNext").addEventListener("click", () => {
    viewMonth += 1;
    if (viewMonth > 11) { viewMonth = 0; viewYear += 1; }
    renderCalendar();
  });
  document.getElementById("calToday").addEventListener("click", () => {
    viewYear = realToday.getFullYear();
    viewMonth = realToday.getMonth();
    renderCalendar();
  });
  clearDaySelect.addEventListener("click", () => {
    selectedDate = null;
    renderCalendar();
    renderUpcoming();
  });
  document.getElementById("scheduleBtn").addEventListener("click", () => {
    alert("Open the schedule-interview form.");
  });

  renderCalendar();
  renderUpcoming();
});
