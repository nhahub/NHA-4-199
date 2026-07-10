document.addEventListener("DOMContentLoaded", function () {
  const modules = ["Employees", "Recruitment", "Attendance", "Leave", "Payroll", "Settings"];
  const actions = ["view", "create", "edit", "delete"];

  const roles = [
    {
      key: "admin",
      name: "Admin",
      users: 12,
      perms: { Employees: [1, 1, 1, 1], Recruitment: [1, 1, 1, 1], Attendance: [1, 1, 1, 1], Leave: [1, 1, 1, 1], Payroll: [1, 1, 1, 1], Settings: [1, 1, 1, 1] },
    },
    {
      key: "hr",
      name: "HR",
      users: 8,
      perms: { Employees: [1, 1, 1, 0], Recruitment: [1, 1, 1, 1], Attendance: [1, 1, 1, 0], Leave: [1, 1, 1, 0], Payroll: [1, 0, 0, 0], Settings: [0, 0, 0, 0] },
    },
    {
      key: "payroll",
      name: "Payroll Admin",
      users: 4,
      perms: { Employees: [1, 0, 0, 0], Recruitment: [0, 0, 0, 0], Attendance: [1, 0, 0, 0], Leave: [1, 0, 1, 0], Payroll: [1, 1, 1, 1], Settings: [0, 0, 0, 0] },
    },
    {
      key: "hiring",
      name: "Hiring Manager",
      users: 15,
      perms: { Employees: [1, 0, 0, 0], Recruitment: [1, 1, 1, 0], Attendance: [0, 0, 0, 0], Leave: [0, 0, 0, 0], Payroll: [0, 0, 0, 0], Settings: [0, 0, 0, 0] },
    },
    {
      key: "employee",
      name: "Employee",
      users: 1189,
      perms: { Employees: [1, 0, 0, 0], Recruitment: [0, 0, 0, 0], Attendance: [1, 1, 0, 0], Leave: [1, 1, 0, 0], Payroll: [1, 0, 0, 0], Settings: [0, 0, 0, 0] },
    },
  ];

  let activeKey = "admin";
  const roleList = document.getElementById("roleList");
  const permBody = document.getElementById("permBody");
  const matrixRoleName = document.getElementById("matrixRoleName");
  const matrixRoleUsers = document.getElementById("matrixRoleUsers");

  function renderRoleList() {
    roleList.innerHTML = roles
      .map(
        (r) => `
      <div class="role-list-item ${r.key === activeKey ? "active" : ""}" data-key="${r.key}">
        <span>${r.name}</span>
        <span class="role-count">${r.users}</span>
      </div>`
      )
      .join("");

    roleList.querySelectorAll(".role-list-item").forEach((el) => {
      el.addEventListener("click", () => {
        activeKey = el.dataset.key;
        renderRoleList();
        renderMatrix();
      });
    });
  }

  function renderMatrix() {
    const role = roles.find((r) => r.key === activeKey);
    matrixRoleName.textContent = role.name;
    matrixRoleUsers.textContent = `${role.users.toLocaleString()} user${role.users !== 1 ? "s" : ""} assigned`;

    permBody.innerHTML = modules
      .map((m, mi) => {
        const cells = actions
          .map(
            (a, ai) => `
          <td>
            <div class="form-check">
              <input class="form-check-input" type="checkbox" data-module="${mi}" data-action="${ai}" ${role.perms[m][ai] ? "checked" : ""} ${role.key === "admin" ? "disabled" : ""} />
            </div>
          </td>`
          )
          .join("");
        return `<tr><td class="ps-2">${m}</td>${cells}</tr>`;
      })
      .join("");
  }

  document.getElementById("savePermBtn").addEventListener("click", () => {
    const role = roles.find((r) => r.key === activeKey);
    permBody.querySelectorAll("input[type=checkbox]").forEach((cb) => {
      const mi = Number(cb.dataset.module);
      const ai = Number(cb.dataset.action);
      role.perms[modules[mi]][ai] = cb.checked ? 1 : 0;
    });
    alert(`Permissions updated for ${role.name}.`);
  });

  document.getElementById("resetPermBtn").addEventListener("click", renderMatrix);

  renderRoleList();
  renderMatrix();
});
