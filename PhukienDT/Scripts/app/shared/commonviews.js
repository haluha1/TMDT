/* PhongTV
 * - configs for date-picker
 */

$(".date-picker").datepicker({
    format: "dd/mm/yyyy",
    maxViewMode: 2,
    todayBtn: "linked",
    clearBtn: true,
    language: "vi",
    daysOfWeekHighlighted: "0",
    todayHighlight: true
});
$(".month-picker").datepicker({
    format: "mm/yyyy",
    minViewMode: 1,
    maxViewMode: 2,
    clearBtn: true,
    language: "vi",
});
$(".year-picker").datepicker({
    format: "yyyy",
    minViewMode: 2,
    maxViewMode: 2,
    clearBtn: true,
    language: "vi",
});