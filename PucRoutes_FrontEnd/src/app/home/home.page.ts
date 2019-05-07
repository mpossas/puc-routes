import { Component } from '@angular/core';
import { HomeService } from './home.service';

import { LoadingController } from '@ionic/angular';

@Component({
  selector: 'app-home',
  templateUrl: 'home.page.html',
  styleUrls: ['home.page.scss'],
})
export class HomePage {

  public vi: number;
  public vf: number;
  public caminho = '';
  public loading: any;

  constructor(private homeService: HomeService,
              private loadingController: LoadingController) {
  }

  async presentLoading() {
    this.loading = await this.loadingController.create({
      message: 'Aguarde...',
      translucent: true
    });
    await this.loading.present();

    this.buscarCaminho();
  }

  buscarCaminho() {
    if (this.vi === null || this.vi === undefined) { return; }

    this.caminho = '';
    this.homeService.obterCaminho(this.vi, this.vf)
      .subscribe(
        async response => {
          response.forEach(aresta => {
            this.caminho += aresta + '  ';
          });
          await this.loading.dismiss();
        },
        async error => {
          console.log(error);
          await this.loading.dismiss();
        }
      );
  }
}
