document.addEventListener("DOMContentLoaded", function () {
  const params = new URLSearchParams(window.location.search);
  const dept = {
    name: params.get("name") || "Engineering",
    manager: params.get("manager") || "Robert Fox",
    title: params.get("title") || "Senior Engineering Director",
    employees: params.get("employees") || "42",
    openRoles: params.get("openRoles") || "3",
    avatar:
      params.get("avatar") ||
      "https://lh3.googleusercontent.com/aida-public/AB6AXuAaSv000TzEkavregoCnr-hGcQdnQUAHvlr7bCw7GcQ-vYFjnMYRkjynIt-OQca9efTmuo3hJvsmo3vMdCfvVvy49Z9Lzs0n4p32xZab8Vvsi2ksAv2eRUKJMNVAKO2_TgwR4q9CITvgsiCcDDjOGKg5nWo8ISeDm45dRNVMaJ3yyn_PiLPNdpafE1eAa7We_8ujsYfVsZZyDM-iTn-LMXvUJGdzBK3nvXROIiC4ioi2WlAFiVi1nL7",
    icon: params.get("icon") || "engineering",
  };

  document.title = `${dept.name} - Department Details | HRMS Enterprise`;
  document.getElementById("crumbName").textContent = dept.name;
  document.getElementById("deptName").textContent = dept.name;
  document.getElementById("deptIcon").textContent = dept.icon;
  document.getElementById("deptManagerAvatar").src = dept.avatar;
  document.getElementById("deptManagerAvatar2").src = dept.avatar;
  document.getElementById("deptManagerName").textContent = dept.manager;
  document.getElementById("deptManagerName2").textContent = dept.manager;
  document.getElementById("deptManagerTitle").textContent = dept.title;
  document.getElementById("deptStaffing").textContent = `${dept.employees} Employees`;
  document.getElementById("deptHiring").textContent = `${dept.openRoles} Open Roles`;
  document.getElementById("statEmployees").textContent = dept.employees;
  document.getElementById("statVacancies").textContent = dept.openRoles;
  document.getElementById("openPositionsBadge").textContent = `${dept.openRoles} OPEN`;

  // Sample employee roster for this department (shared visual language with employees.html)
  const roster = [
    { name: "Leslie Alexander", email: "leslie.a@company.com", role: "Senior Software Engineer", hire: "Oct 12, 2021", status: "Active", avatar: "https://images.unsplash.com/photo-1534528741775-53994a69daeb?w=100&auto=format&fit=crop&q=60" },
    { name: dept.manager, email: `${dept.manager.split(" ")[0].toLowerCase()}@company.com`, role: dept.title, hire: "Mar 05, 2019", status: "Active", avatar: dept.avatar },
    { name: "Jane Cooper", email: "jane.c@company.com", role: "Lead Developer", hire: "Jan 22, 2022", status: "Remote", avatar: "https://images.unsplash.com/photo-1494790108377-be9c29b29330?w=100&auto=format&fit=crop&q=60" },
    { name: "Cody Fisher", email: "cody.f@company.com", role: "Software Engineer", hire: "Jun 14, 2023", status: "Active", avatar: "https://images.unsplash.com/photo-1507003211169-0a1dd7228f2d?w=100&auto=format&fit=crop&q=60" },
  ];
  const badgeClass = (s) => (s === "Active" ? "chip-success" : s === "Remote" ? "chip-primary" : "chip-warning");

  const body = document.getElementById("deptEmployeeBody");
  body.innerHTML = roster
    .map(
      (e) => `
    <tr class="table-row-link" onclick="location.href='../employees/profile.html?${new URLSearchParams({ name: e.name, title: e.role, dept: dept.name, manager: dept.manager, hire: e.hire, status: e.status, email: e.email, avatar: e.avatar })}'">
      <td class="ps-3">
        <div class="d-flex align-items-center gap-2">
          <img class="row-avatar" width="32" height="32" src="${e.avatar}" alt="${e.name}">
          <div>
            <p class="mb-0 small fw-bold">${e.name}</p>
            <small class="text-muted">${e.email}</small>
          </div>
        </div>
      </td>
      <td class="small">${e.role}</td>
      <td class="small text-muted">${e.hire}</td>
      <td><span class="chip ${badgeClass(e.status)}">${e.status}</span></td>
      <td class="text-end pe-3"><button class="icon-btn" onclick="event.stopPropagation()"><span class="material-symbols-outlined" style="font-size:18px">more_vert</span></button></td>
    </tr>
  `
    )
    .join("");

  // Open positions for this department
  const jobs = [
    { title: "Senior Full Stack Developer", team: `${dept.name} Team • Remote` },
    { title: "DevOps Engineer", team: `${dept.name} Team • Hybrid` },
    { title: "QA Specialist", team: `${dept.name} Team • On-site` },
  ];
  document.getElementById("jobCardsWrap").innerHTML = jobs
    .map(
      (j) => `
    <div class="panel job-card" onclick="location.href='../recruitment/recruitment.html'">
      <div class="d-flex justify-content-between align-items-start mb-2">
        <span class="small fw-bold text-uppercase" style="color:var(--primary)">Active</span>
        <small class="text-muted">Hiring: 1</small>
      </div>
      <h5 class="fw-bold mb-1" style="font-size:14px">${j.title}</h5>
      <p class="text-muted mb-3" style="font-size:12px">${j.team}</p>
      <div class="d-flex align-items-center justify-content-between">
        <div class="d-flex interviewer-stack"></div>
        <span class="d-flex align-items-center gap-1 small" style="color:var(--primary)">
          Details <span class="material-symbols-outlined" style="font-size:14px">arrow_forward</span>
        </span>
      </div>
    </div>
  `
    )
    .join("");

  // Tabs (visual only, Overview stays populated)
  const tabLinks = document.querySelectorAll("#mainTabNav .nav-link");
  tabLinks.forEach((tab) => {
    tab.addEventListener("click", function (e) {
      e.preventDefault();
      tabLinks.forEach((item) => item.classList.remove("active-tab"));
      this.classList.add("active-tab");
    });
  });
});
