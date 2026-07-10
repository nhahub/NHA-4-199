document.addEventListener("DOMContentLoaded", function () {
  const params = new URLSearchParams(window.location.search);
  const data = {
    name: params.get("name") || "Elena Gilbert",
    position: params.get("position") || "Senior Full Stack Developer",
    stage: params.get("stage") || "Applied",
    applied: params.get("applied") || "2026-07-05",
    email: params.get("email") || "elena.gilbert@mail.com",
    avatar:
      params.get("avatar") ||
      "https://images.unsplash.com/photo-1544005313-94ddf0286df2?w=200&auto=format&fit=crop&q=60",
  };

  function formatDate(iso) {
    return new Date(iso + "T00:00:00").toLocaleDateString("en-US", { month: "short", day: "numeric", year: "numeric" });
  }

  document.title = `${data.name} - Candidate Profile | HRMS Enterprise`;
  document.getElementById("crumbName").textContent = data.name;
  document.getElementById("cName").textContent = data.name;
  document.getElementById("cPosition").textContent = data.position;
  document.getElementById("cAvatar").src = data.avatar;
  document.getElementById("cEmail").textContent = data.email;
  document.getElementById("cAppliedDate").textContent = formatDate(data.applied);
  document.getElementById("cAppPosition").textContent = data.position;
  document.getElementById("cAppDate").textContent = formatDate(data.applied);
  document.getElementById("cResumeName").textContent = `${data.name.replace(/\s+/g, "_")}_Resume.pdf`;

  const stageEl = document.getElementById("cStage");
  stageEl.textContent = data.stage;
  stageEl.className = `stage-pill stage-${data.stage.toLowerCase()}`;

  document.getElementById("moveStageBtn").addEventListener("click", () => {
    alert(`Move ${data.name} to the next recruitment stage.`);
  });

  // Tabs
  document.addEventListener("click", (e) => {
    if (e.target.closest("#candTabs .nav-link")) {
      e.preventDefault();
      const link = e.target.closest("#candTabs .nav-link");
      document.querySelectorAll("#candTabs .nav-link").forEach((t) => t.classList.remove("active-tab"));
      link.classList.add("active-tab");

      const targetTabName = link.getAttribute("data-tab");
      document.querySelectorAll(".tab-pane-content").forEach((c) => c.classList.remove("show-tab"));
      const targetContainer = document.getElementById(`${targetTabName}Tab`);
      if (targetContainer) targetContainer.classList.add("show-tab");
    }
  });
});
