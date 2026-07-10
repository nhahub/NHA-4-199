document.addEventListener("DOMContentLoaded", function () {
  const navItems = document.querySelectorAll("#settingsNav .settings-nav-item");
  const panes = document.querySelectorAll(".settings-pane");

  navItems.forEach((item) => {
    item.addEventListener("click", () => {
      navItems.forEach((n) => n.classList.remove("active"));
      item.classList.add("active");
      panes.forEach((p) => p.classList.remove("show-pane"));
      document.getElementById(`pane-${item.dataset.pane}`).classList.add("show-pane");
    });
  });

  document.querySelectorAll(".settings-save").forEach((btn) => {
    btn.addEventListener("click", () => {
      const pane = btn.closest(".settings-pane");
      const title = pane.querySelector(".settings-section-title").textContent;
      alert(`${title} settings saved.`);
    });
  });

  const testSmtpBtn = document.getElementById("testSmtpBtn");
  if (testSmtpBtn) {
    testSmtpBtn.addEventListener("click", () => {
      testSmtpBtn.disabled = true;
      testSmtpBtn.textContent = "Testing...";
      setTimeout(() => {
        testSmtpBtn.disabled = false;
        testSmtpBtn.textContent = "Test Connection";
        alert("SMTP connection test succeeded.");
      }, 900);
    });
  }
});
