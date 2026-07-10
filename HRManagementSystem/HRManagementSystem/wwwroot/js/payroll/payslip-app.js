document.addEventListener("DOMContentLoaded", function () {
  const fmt = (n) => `$${n.toLocaleString("en-US", { minimumFractionDigits: 2, maximumFractionDigits: 2 })}`;
  const parseVal = (id) => Number(document.getElementById(id).textContent.replace(/[^0-9.-]/g, ""));

  function recalc() {
    const earnings = ["eBasic", "eAllow", "eBonus", "eOT"].reduce((sum, id) => sum + parseVal(id), 0);
    const deductions = ["dTax", "dLeave", "dOther"].reduce((sum, id) => sum + parseVal(id), 0);
    document.getElementById("eTotal").textContent = fmt(earnings);
    document.getElementById("dTotal").textContent = fmt(deductions);
    document.getElementById("netSalary").textContent = fmt(earnings - deductions);
  }
  recalc();

  document.getElementById("printBtn").addEventListener("click", () => window.print());

  document.getElementById("downloadBtn").addEventListener("click", () => {
    // In production this calls the payroll API to generate a signed PDF.
    // Here we fall back to the browser's print-to-PDF flow.
    window.print();
  });
});
