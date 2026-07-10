// Shared app shell: injects the sidebar + topbar used on every HRMS page,
// so the navigation, colors and structure stay identical everywhere.
// Also owns the dark/light theme toggle (persisted via localStorage) so the
// preference is consistent across every module.
(function () {
  const THEME_KEY = "hrms-theme";

  // Every page lives at pages/<module>/<file>.html, so a link to another
  // module is always "../<module>/<file>.html" regardless of which page
  // is currently rendering this shell.
  const NAV_ITEMS = [
    { key: "dashboard", label: "Dashboard", icon: "dashboard", href: "../dashboard/dashboard.html" },
    { key: "employees", label: "Employees", icon: "group", href: "../employees/employees.html" },
    { key: "departments", label: "Departments", icon: "domain", href: "../departments/departments.html" },
    { key: "recruitment", label: "Recruitment", icon: "work", href: "../recruitment/recruitment.html" },
    { key: "attendance", label: "Attendance", icon: "how_to_reg", href: "../attendance/attendance-records.html" },
    { key: "payroll", label: "Payroll", icon: "payments", href: "../payroll/payroll.html" },
    { key: "leave", label: "Leave", icon: "event_available", href: "../leave/leave.html" },
    { key: "settings", label: "Administration", icon: "admin_panel_settings", href: "../admin/admin-users.html" },
  ];

  function renderSidebar(active) {
    const items = NAV_ITEMS.map(
      (item) => `
      <a href="${item.href}" class="nav-item${item.key === active ? " active" : ""}">
        <span class="material-symbols-outlined">${item.icon}</span>${item.label}
      </a>`
    ).join("");

    return `
      <div class="brand">
        <span class="material-symbols-outlined brand-icon">hub</span>
        <div>
          <div class="brand-name">HRMS</div>
          <div class="brand-sub">Enterprise</div>
        </div>
      </div>
      <nav class="nav-menu">${items}</nav>`;
  }

  function renderTopbar(title, subtitle) {
    return `
      <div class="topbar-left">
        <button class="mobile-nav-toggle" id="mobileNavToggle" title="Open menu" aria-label="Open menu">
          <span class="material-symbols-outlined">menu</span>
        </button>
        <div>
          <div class="portal-title">${title}</div>
          <div class="portal-sub">${subtitle}</div>
        </div>
      </div>
      <div class="topbar-right">
        <div class="search">
          <span class="material-symbols-outlined">search</span>
          <input type="text" placeholder="Search employees, reports..." />
        </div>
        <button class="theme-toggle" id="themeToggle" title="Toggle dark mode" aria-label="Toggle dark mode">
          <span class="theme-toggle-track">
            <span class="theme-toggle-thumb">
              <span class="material-symbols-outlined" id="themeToggleIcon">dark_mode</span>
            </span>
          </span>
        </button>
        <button class="icon-btn" title="Notifications">
          <span class="material-symbols-outlined">notifications</span><span class="badge-dot"></span>
        </button>
        <button class="icon-btn" title="Help">
          <span class="material-symbols-outlined">help</span>
        </button>
        <div class="avatar">AV</div>
      </div>`;
  }

  function currentTheme() {
    return document.documentElement.getAttribute("data-bs-theme") === "dark" ? "dark" : "light";
  }

  function setTheme(theme) {
    if (theme === "dark") {
      document.documentElement.setAttribute("data-bs-theme", "dark");
    } else {
      document.documentElement.removeAttribute("data-bs-theme");
    }
    localStorage.setItem(THEME_KEY, theme);
    const icon = document.getElementById("themeToggleIcon");
    if (icon) icon.textContent = theme === "dark" ? "light_mode" : "dark_mode";
  }

  function initMobileNav() {
    const sidebarEl = document.getElementById("sidebar");
    if (!sidebarEl) return;

    let backdrop = document.querySelector(".sidebar-backdrop");
    if (!backdrop) {
      backdrop = document.createElement("div");
      backdrop.className = "sidebar-backdrop";
      document.body.appendChild(backdrop);
    }

    const toggleBtn = document.getElementById("mobileNavToggle");

    function openNav() {
      sidebarEl.classList.add("open");
      backdrop.classList.add("open");
    }
    function closeNav() {
      sidebarEl.classList.remove("open");
      backdrop.classList.remove("open");
    }

    toggleBtn?.addEventListener("click", () => {
      sidebarEl.classList.contains("open") ? closeNav() : openNav();
    });
    backdrop.addEventListener("click", closeNav);
    // Close the drawer automatically once a nav link is tapped on mobile.
    sidebarEl.querySelectorAll(".nav-item").forEach((link) => {
      link.addEventListener("click", closeNav);
    });
  }

  function initThemeToggle() {
    const icon = document.getElementById("themeToggleIcon");
    if (icon) icon.textContent = currentTheme() === "dark" ? "light_mode" : "dark_mode";

    const btn = document.getElementById("themeToggle");
    btn?.addEventListener("click", () => {
      setTheme(currentTheme() === "dark" ? "light" : "dark");
    });
  }

  function init() {
    const body = document.body;
    const active = body.dataset.active || "";
    const title = body.dataset.title || "HRMS Portal";
    const subtitle = body.dataset.subtitle || "Human Resource Management System";

    const sidebarEl = document.getElementById("sidebar");
    const topbarEl = document.getElementById("topbar");
    if (sidebarEl) sidebarEl.innerHTML = renderSidebar(active);
    if (topbarEl) topbarEl.innerHTML = renderTopbar(title, subtitle);

    initThemeToggle();
    initMobileNav();

    // Let page-specific scripts know the shell is ready (e.g. to wire up buttons inside the topbar/sidebar).
    document.dispatchEvent(new CustomEvent("hrms:layout-ready"));
  }

  if (document.readyState === "loading") {
    document.addEventListener("DOMContentLoaded", init);
  } else {
    init();
  }
})();
