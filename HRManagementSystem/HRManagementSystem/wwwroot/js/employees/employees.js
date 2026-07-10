document.addEventListener("DOMContentLoaded", function () {
  const employees = [
    { name: "Robert Fox", email: "robert.fox@enterprise.com", dept: "Engineering", manager: "Kristin Watson", hire: "Oct 12, 2021", status: "Active", title: "Senior Software Engineer", avatar: "https://images.unsplash.com/photo-1534528741775-53994a69daeb?w=100&auto=format&fit=crop&q=60" },
    { name: "Jane Cooper", email: "jane.cooper@enterprise.com", dept: "Design", manager: "Jacob Jones", hire: "Jan 05, 2022", status: "Remote", title: "Lead Developer", avatar: "https://images.unsplash.com/photo-1494790108377-be9c29b29330?w=100&auto=format&fit=crop&q=60" },
    { name: "Cameron Williamson", email: "cameron.w@enterprise.com", dept: "HR & Ops", manager: "Self", hire: "Mar 15, 2019", status: "Active", title: "HR Director", avatar: "https://images.unsplash.com/photo-1507003211169-0a1dd7228f2d?w=100&auto=format&fit=crop&q=60" },
    { name: "Brooklyn Simmons", email: "brooklyn.s@enterprise.com", dept: "Marketing", manager: "Bessie Cooper", hire: "Dec 10, 2022", status: "On Leave", title: "Marketing Specialist", avatar: "https://images.unsplash.com/photo-1438761681033-6461ffad8d80?w=100&auto=format&fit=crop&q=60" },
    { name: "Leslie Alexander", email: "leslie.a@enterprise.com", dept: "Engineering", manager: "Robert Fox", hire: "May 12, 2023", status: "Active", title: "Software Engineer", avatar: "https://images.unsplash.com/photo-1628157582853-a796fa650a6a?w=100&auto=format&fit=crop&q=60" },
  ];

  const badgeClass = (s) => (s === "Active" ? "chip-success" : s === "Remote" ? "chip-primary" : "chip-warning");

  function goToProfile(emp) {
    const params = new URLSearchParams({
      name: emp.name,
      title: emp.title,
      dept: emp.dept,
      manager: emp.manager,
      hire: emp.hire,
      status: emp.status,
      email: emp.email,
      avatar: emp.avatar,
    });
    window.location.href = "profile.html?" + params.toString();
  }

  function render(list) {
    const body = document.getElementById("employeeBody");
    if (!body) return;

    if (!list.length) {
      body.innerHTML = `<tr><td colspan="8" style="padding:48px; text-align:center; color:var(--muted)">No employees found.</td></tr>`;
      return;
    }

    body.innerHTML = list
      .map(
        (e, i) => `
      <tr class="table-row-link" data-idx="${i}">
        <td class="ps-4"><img class="row-avatar" src="${e.avatar}" alt="${e.name}"></td>
        <td class="fw-semibold" style="color: var(--text);">${e.name}</td>
        <td class="text-muted">${e.email}</td>
        <td>${e.dept}</td>
        <td>${e.manager}</td>
        <td>${e.hire}</td>
        <td><span class="chip ${badgeClass(e.status)}">${e.status}</span></td>
        <td class="text-end pe-4">
          <button class="icon-btn" data-action="menu" data-idx="${i}"><span class="material-symbols-outlined" style="font-size: 20px;">more_vert</span></button>
        </td>
      </tr>
    `
      )
      .join("");

    // Row click (except the action button) opens the employee profile.
    body.querySelectorAll("tr[data-idx]").forEach((row) => {
      row.addEventListener("click", (e) => {
        if (e.target.closest('[data-action="menu"]')) return;
        const emp = list[Number(row.dataset.idx)];
        goToProfile(emp);
      });
    });
    body.querySelectorAll('[data-action="menu"]').forEach((btn) => {
      btn.addEventListener("click", (e) => {
        e.stopPropagation();
        const emp = list[Number(btn.dataset.idx)];
        goToProfile(emp);
      });
    });
  }

  function applyFilters() {
    const q = document.getElementById("employeeSearch").value.toLowerCase();
    const d = document.getElementById("filterDept").value;
    const s = document.getElementById("filterStatus").value;

    const filtered = employees.filter(
      (e) =>
        (!q || e.name.toLowerCase().includes(q) || e.email.toLowerCase().includes(q)) &&
        (!d || e.dept === d) &&
        (!s || e.status === s)
    );
    render(filtered);
  }

  document.getElementById("employeeSearch").addEventListener("input", applyFilters);
  document.getElementById("filterDept").addEventListener("change", applyFilters);
  document.getElementById("filterStatus").addEventListener("change", applyFilters);

  render(employees);
});
