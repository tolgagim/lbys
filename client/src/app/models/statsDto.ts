 
export class StatsDto {
  productCount: number;
  brandCount: number;
  userCount: number;
  roleCount: number;
  dataEnterBarChart: ChartSeries[];
  productByBrandTypePieChart: { [key: string]: number } | null;

  constructor() {
      this.productCount = 0;
      this.brandCount = 0;
      this.userCount = 0;
      this.roleCount = 0;
      this.dataEnterBarChart = [];
      this.productByBrandTypePieChart = null;
  }
}

// ChartSeries sınıfının TypeScript karşılığı
class ChartSeries {
  name?: string;
  data?: number[];

  constructor(name?: string, data?: number[]) {
      this.name = name;
      this.data = data;
  }
}
