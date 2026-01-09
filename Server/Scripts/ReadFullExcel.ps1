$excel = New-Object -ComObject Excel.Application
$excel.Visible = $false
$workbook = $excel.Workbooks.Open('C:\Users\tolga_ofis\Desktop\VemGonder\seedhata.xls')
$sheet = $workbook.Sheets.Item(1)
$usedRange = $sheet.UsedRange
$rows = $usedRange.Rows.Count
$cols = $usedRange.Columns.Count

$output = @()
for ($i = 1; $i -le $rows; $i++) {
    $row = @{}
    for ($j = 1; $j -le $cols; $j++) {
        $header = $sheet.Cells.Item(1, $j).Text
        $val = $sheet.Cells.Item($i, $j).Text
        $row[$header] = $val
    }
    $output += $row
}

$workbook.Close($false)
$excel.Quit()
[System.Runtime.Interopservices.Marshal]::ReleaseComObject($excel) | Out-Null

# Group by table name and issue type
$grouped = $output | Where-Object { $_.'Görüntü Adi' } | Group-Object { $_.'Görüntü Adi' }

foreach ($group in $grouped) {
    Write-Host "=== $($group.Name) ==="
    $issues = $group.Group | Group-Object { $_.'Açiklama' + '|' + $_.'Sorunlu Degerler' }
    foreach ($issue in $issues) {
        $parts = $issue.Name -split '\|'
        Write-Host "  $($parts[0]): $($parts[1])"
    }
}
