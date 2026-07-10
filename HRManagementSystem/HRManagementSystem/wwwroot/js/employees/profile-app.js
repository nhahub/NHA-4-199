document.addEventListener("DOMContentLoaded", function () {
  // Populate the header from whatever employee was clicked on employees.html.
  // Falls back to a default record when the page is opened directly.
  const params = new URLSearchParams(window.location.search);
  const data = {
    name: params.get("name") || "Robert Fox",
    title: params.get("title") || "Senior Software Engineer",
    dept: params.get("dept") || "Engineering",
    manager: params.get("manager") || "Kristin Watson",
    hire: params.get("hire") || "Oct 12, 2021",
    status: params.get("status") || "Active",
    email: params.get("email") || "robert.fox@enterprise.com",
    avatar:
      params.get("avatar") ||
      "https://images.unsplash.com/photo-1534528741775-53994a69daeb?w=200&auto=format&fit=crop&q=60",
  };

  const initials = data.manager
    .split(" ")
    .map((w) => w[0])
    .join("")
    .slice(0, 2)
    .toUpperCase();

  document.title = `${data.name} - Employee Profile | HRMS Enterprise`;
  document.getElementById("crumbName").textContent = data.name;
  document.getElementById("pName").textContent = data.name;
  document.getElementById("pTitle").textContent = data.title;
  document.getElementById("pDept").textContent = data.dept;
  document.getElementById("pDept2").textContent = data.dept;
  document.getElementById("pManager").textContent = data.manager === "Self" ? "—" : data.manager;
  document.getElementById("pManagerInitials").textContent = data.manager === "Self" ? "--" : initials;
  document.getElementById("pHire").textContent = data.hire;
  document.getElementById("pEmail").textContent = data.email;
  document.getElementById("pAvatar").src = data.avatar;
  document.getElementById("pEmpStatus").textContent = data.status === "Remote" ? "Full-time (Remote)" : "Full-time";

  const statusEl = document.getElementById("pStatus");
  statusEl.textContent = data.status;
  statusEl.classList.remove("bg-success");
  if (data.status === "Active") statusEl.classList.add("bg-success");
  else if (data.status === "Remote") statusEl.classList.add("bg-primary");
  else statusEl.classList.add("bg-warning");

  // Tabs
  document.addEventListener("click", (e) => {
    if (e.target.matches("#profileTabs .nav-link")) {
      e.preventDefault();
      document.querySelectorAll("#profileTabs .nav-link").forEach((t) => t.classList.remove("active-tab"));
      e.target.classList.add("active-tab");

      const targetTabName = e.target.getAttribute("data-tab");
      document.querySelectorAll(".tab-pane-content").forEach((c) => c.classList.remove("show-tab"));
      const targetContainer = document.getElementById(`${targetTabName}Tab`);
      if (targetContainer) targetContainer.classList.add("show-tab");
    }

    if (e.target.closest(".view-all-attendance-link")) {
      e.preventDefault();
      document.querySelector("#profileTabs [data-tab='attendance']")?.click();
    }
    if (e.target.closest(".view-all-leaves-link")) {
      e.preventDefault();
      document.querySelector("#profileTabs [data-tab='leave']")?.click();
    }
    if (e.target.closest("#editProfileBtn")) {
      alert("Open the edit-profile modal for this employee.");
    }
  });
});
