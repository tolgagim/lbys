$excel = New-Object -ComObject Excel.Application
$excel.Visible = $false
$workbook = $excel.Workbooks.Open('C:\Users\tolga_ofis\Desktop\VemGonder\seedhata.xls')
$sheet = $workbook.Sheets.Item(1)
$usedRange = $sheet.UsedRange
$rows = $usedRange.Rows.Count

Write-Host "Total rows: $rows"
Write-Host ""

# Get unique issues
$issues = @{}
for ($i = 2; $i -le $rows; $i++) {
    $tableName = $sheet.Cells.Item($i, 2).Text
    $issueType = $sheet.Cells.Item($i, 3).Text
    $issueCol = $sheet.Cells.Item($i, 4).Text
    $issueVal = $sheet.Cells.Item($i, 5).Text

    $key = "$tableName|$issueCol|$issueVal"
    if (-not $issues.ContainsKey($key)) {
        $issues[$key] = @{
            Table = $tableName
            Column = $issueCol
            Value = $issueVal
            Type = $issueType
        }
    }
}

Write-Host "Unique issues: $($issues.Count)"
Write-Host ""

foreach ($issue in $issues.Values | Sort-Object { $_.Table }) {
    Write-Host "$($issue.Table) | $($issue.Column) | $($issue.Value)"
}

$workbook.Close($false)
$excel.Quit()
[System.Runtime.Interopservices.Marshal]::ReleaseComObject($excel) | Out-Null
