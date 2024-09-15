import { CommonModule } from "@angular/common";
import { HttpClientModule } from "@angular/common/http";
import { NgModule, Optional, SkipSelf } from "@angular/core";
import { RouterModule } from "@angular/router";

@NgModule({
  declarations: [],
  imports: [CommonModule, RouterModule, HttpClientModule]
})
export class CoreModule {
  constructor(@Optional() @SkipSelf() parentModule?: CoreModule)
  {
    if (parentModule) {
      throw new Error("CoreModule has been loaded. Do not import this in any module except AppModule");
    }
  }
}
