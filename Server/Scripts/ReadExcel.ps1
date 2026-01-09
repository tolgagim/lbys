$excel = New-Object -ComObject Excel.Application
$excel.Visible = $false
$workbook = $excel.Workbooks.Open('C:\Users\tolga_ofis\Desktop\VemGonder\seedhata.xls')
$sheet = $workbook.Sheets.Item(1)
$usedRange = $sheet.UsedRange
$rows = $usedRange.Rows.Count
$cols = $usedRange.Columns.Count

Write-Host "Rows: $rows, Cols: $cols"
Write-Host "---"

for ($i = 1; $i -le [Math]::Min($rows, 150); $i++) {
    $line = ""
    for ($j = 1; $j -le $cols; $j++) {
        $val = $sheet.Cells.Item($i, $j).Text
        $line += $val + "|"
    }
    Write-Host $line
}

$workbook.Close($false)
$excel.Quit()
[System.Runtime.Interopservices.Marshal]::ReleaseComObject($excel) | Out-Null
