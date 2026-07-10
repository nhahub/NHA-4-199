document.addEventListener("DOMContentLoaded", function () {
  const records = [
    { name: "Sarah Jenkins", dept: "Marketing", date: "2026-07-09", shift: "General (9:00 - 18:00)", checkIn: "08:52 AM", checkOut: "05:45 PM", hours: 8.9, status: "On Time", source: "Biometric", avatar: "https://images.unsplash.com/photo-1544005313-94ddf0286df2?w=100&auto=format&fit=crop&q=60" },
    { name: "Michael Chang", dept: "Engineering", date: "2026-07-09", shift: "General (9:00 - 18:00)", checkIn: "09:20 AM", checkOut: "06:10 PM", hours: 8.8, status: "Late", source: "Biometric", avatar: "https://images.unsplash.com/photo-1517841905240-472988babdf9?w=100&auto=format&fit=crop&q=60" },
    { name: "Elena Rodriguez", dept: "Sales", date: "2026-07-09", shift: "General (9:00 - 18:00)", checkIn: "08:47 AM", checkOut: "05:30 PM", hours: 8.7, status: "On Time", source: "Mobile App", avatar: "https://images.unsplash.com/photo-1502685104226-ee32379fefbe?w=100&auto=format&fit=crop&q=60" },
    { name: "David Kim", dept: "Finance", date: "2026-07-09", shift: "General (9:00 - 18:00)", checkIn: "—", checkOut: "—", hours: 0, status: "Absent", source: "System", avatar: "https://images.unsplash.com/photo-1560250097-0b93528c311a?w=100&auto=format&fit=crop&q=60" },
    { name: "Amanda Foster", dept: "HR & Ops", date: "2026-07-09", shift: "General (9:00 - 18:00)", checkIn: "—", checkOut: "—", hours: 0, status: "On Leave", source: "System", avatar: "https://images.unsplash.com/photo-1489424731084-a5d8b219a5bb?w=100&auto=format&fit=crop&q=60" },
    { name: "Robert Fox", dept: "Engineering", date: "2026-07-09", shift: "General (9:00 - 18:00)", checkIn: "08:58 AM", checkOut: "06:02 PM", hours: 9.1, status: "On Time", source: "Biometric", avatar: "https://images.unsplash.com/photo-1534528741775-53994a69daeb?w=100&auto=format&fit=crop&q=60" },
    { name: "Jane Cooper", dept: "Engineering", date: "2026-07-09", shift: "General (9:00 - 18:00)", checkIn: "09:32 AM", checkOut: "01:15 PM", hours: 3.7, status: "Half Day", source: "Manual", avatar: "https://images.unsplash.com/photo-1494790108377-be9c29b29330?w=100&auto=format&fit=crop&q=60" },
    { name: "Leslie Alexander", dept: "Engineering", date: "2026-07-08", shift: "General (9:00 - 18:00)", checkIn: "08:49 AM", checkOut: "05:52 PM", hours: 9.1, status: "On Time", source: "Biometric", avatar: "https://images.unsplash.com/photo-1628157582853-a796fa650a6a?w=100&auto=format&fit=crop&q=60" },
    { name: "Cody Fisher", dept: "Product Design", date: "2026-07-08", shift: "Flexible (10:00 - 19:00)", checkIn: "10:14 AM", checkOut: "07:05 PM", hours: 8.9, status: "Late", source: "Mobile App", avatar: "https://images.unsplash.com/photo-1507003211169-0a1dd7228f2d?w=100&auto=format&fit=crop&q=60" },
    { name: "Kristin Watson", dept: "Marketing", date: "2026-07-08", shift: "General (9:00 - 18:00)", checkIn: "08:41 AM", checkOut: "05:38 PM", hours: 8.9, status: "On Time", source: "Web Portal", avatar: "https://images.unsplash.com/photo-1438761681033-6461ffad8d80?w=100&auto=format&fit=crop&q=60" },
    { name: "Guy Hawkins", dept: "Sales", date: "2026-07-08", shift: "General (9:00 - 18:00)", checkIn: "—", checkOut: "—", hours: 0, status: "Absent", source: "System", avatar: "https://images.unsplash.com/photo-1500648767791-00dcc994a43e?w=100&auto=format&fit=crop&q=60" },
    { name: "Arlene McCoy", dept: "HR & Ops", date: "2026-07-08", shift: "General (9:00 - 18:00)", checkIn: "08:55 AM", checkOut: "05:40 PM", hours: 8.8, status: "On Time", source: "Biometric", avatar: "https://images.unsplash.com/photo-1487412720507-e7ab37603c6f?w=100&auto=format&fit=crop&q=60" },
  ];

  const sourceIcon = (s) =>
    ({
      Biometric: "fingerprint",
      "Mobile App": "smartphone",
      "Web Portal": "language",
      Manual: "edit_note",
      System: "dns",
    }[s] || "help");

  const statusClass = (s) =>
    ({
      "On Time": "status-on-time",
      Late: "status-late",
      "Half Day": "status-halfday",
      Absent: "chip-danger",
      "On Leave": "chip-primary",
    }[s] || "chip-primary");

  const body = document.getElementById("recBody");
  const searchInput = document.getElementById("recSearch");
  const deptFilter = document.getElementById("recDept");
  const statusFilter = document.getElementById("recStatus");
  const dateFrom = document.getElementById("recDateFrom");
  const dateTo = document.getElementById("recDateTo");
  const clearBtn = document.getElementById("recClear");
  const paginationInfo = document.getElementById("recPaginationInfo");

  let sortKey = null;
  let sortDir = 1;

  function formatDate(iso) {
    return new Date(iso + "T00:00:00").toLocaleDateString("en-US", { month: "short", day: "numeric", year: "numeric" });
  }

  function formatHours(h) {
    if (!h) return "—";
    const hrs = Math.floor(h);
    const mins = Math.round((h - hrs) * 60);
    return `${hrs}h ${mins}m`;
  }

  function renderSkeleton() {
    body.innerHTML = Array.from({ length: 6 })
      .map(
        () => `
      <tr>
        <td class="ps-4"><span class="skeleton-bar" style="width:140px"></span></td>
        <td><span class="skeleton-bar" style="width:90px"></span></td>
        <td><span class="skeleton-bar" style="width:80px"></span></td>
        <td><span class="skeleton-bar" style="width:120px"></span></td>
        <td><span class="skeleton-bar" style="width:70px"></span></td>
        <td><span class="skeleton-bar" style="width:70px"></span></td>
        <td><span class="skeleton-bar" style="width:60px"></span></td>
        <td><span class="skeleton-bar" style="width:70px"></span></td>
        <td><span class="skeleton-bar" style="width:80px"></span></td>
        <td class="text-end pe-4"><span class="skeleton-bar" style="width:24px"></span></td>
      </tr>`
      )
      .join("");
  }

  function render(list) {
    if (!list.length) {
      body.innerHTML = `
        <tr><td colspan="10">
          <div class="empty-state">
            <span class="material-symbols-outlined">event_busy</span>
            <p>No attendance records match your filters.</p>
          </div>
        </td></tr>`;
      paginationInfo.textContent = `Showing 0 of ${records.length} records`;
      return;
    }

    body.innerHTML = list
      .map(
        (r) => `
      <tr>
        <td class="ps-4">
          <div class="emp">
            <img class="row-avatar" src="${r.avatar}" alt="${r.name}">
            <div class="fw-semibold" style="color:var(--text)">${r.name}</div>
          </div>
        </td>
        <td>${r.dept}</td>
        <td class="text-muted">${formatDate(r.date)}</td>
        <td class="text-muted">${r.shift}</td>
        <td>${r.checkIn}</td>
        <td>${r.checkOut}</td>
        <td>${formatHours(r.hours)}</td>
        <td><span class="badge-status ${statusClass(r.status)}">${r.status}</span></td>
        <td><span class="source-tag"><span class="material-symbols-outlined">${sourceIcon(r.source)}</span>${r.source}</span></td>
        <td class="text-end pe-4">
          <div class="dropdown">
            <button class="icon-btn" data-bs-toggle="dropdown" aria-expanded="false">
              <span class="material-symbols-outlined" style="font-size: 20px">more_vert</span>
            </button>
            <ul class="dropdown-menu dropdown-menu-end">
              <li><a class="dropdown-item" href="#" data-action="view">View details</a></li>
              <li><a class="dropdown-item" href="#" data-action="correct">Request correction</a></li>
            </ul>
          </div>
        </td>
      </tr>`
      )
      .join("");

    paginationInfo.textContent = `Showing ${list.length} of ${records.length} records`;

    body.querySelectorAll("[data-action]").forEach((el) => {
      el.addEventListener("click", (e) => {
        e.preventDefault();
        const row = el.closest("tr");
        const name = row.querySelector(".fw-semibold").textContent;
        if (el.dataset.action === "view") alert(`Viewing attendance detail for ${name}.`);
        if (el.dataset.action === "correct") alert(`Opening correction request for ${name}.`);
      });
    });
  }

  function getFiltered() {
    const q = searchInput.value.toLowerCase().trim();
    const dept = deptFilter.value;
    const status = statusFilter.value;
    const from = dateFrom.value;
    const to = dateTo.value;

    let filtered = records.filter((r) => {
      if (q && !r.name.toLowerCase().includes(q)) return false;
      if (dept && r.dept !== dept) return false;
      if (status && r.status !== status) return false;
      if (from && r.date < from) return false;
      if (to && r.date > to) return false;
      return true;
    });

    if (sortKey) {
      filtered = filtered.slice().sort((a, b) => {
        const va = a[sortKey];
        const vb = b[sortKey];
        if (va < vb) return -1 * sortDir;
        if (va > vb) return 1 * sortDir;
        return 0;
      });
    }
    return filtered;
  }

  function applyFilters() {
    render(getFiltered());
  }

  [searchInput, deptFilter, statusFilter, dateFrom, dateTo].forEach((el) =>
    el.addEventListener("input", applyFilters)
  );

  clearBtn.addEventListener("click", () => {
    searchInput.value = "";
    deptFilter.value = "";
    statusFilter.value = "";
    dateFrom.value = "";
    dateTo.value = "";
    applyFilters();
  });

  document.querySelectorAll(".sortable").forEach((el) => {
    el.addEventListener("click", () => {
      const key = el.dataset.sort;
      if (sortKey === key) {
        sortDir *= -1;
      } else {
        sortKey = key;
        sortDir = 1;
      }
      document.querySelectorAll(".sortable").forEach((s) => s.classList.remove("sort-active"));
      el.classList.add("sort-active");
      applyFilters();
    });
  });

  document.getElementById("exportBtn").addEventListener("click", () => {
    alert("Exporting current attendance record view to CSV.");
  });

  renderSkeleton();
  setTimeout(applyFilters, 450);
});
