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

  constructor(private homeService: HomeService,
              private loadingController: LoadingController) {
  }

  async presentLoading() {
    const loading = await this.loadingController.create({
      message: 'Aguarde...',
    });
    await loading.present();

    await this.buscarCaminho();
    await loading.dismiss();
  }

  async buscarCaminho() {
    if (this.vi === null || this.vi === undefined) { return; }

    this.caminho = '';
    this.homeService.obterCaminho(this.vi, this.vf)
      .subscribe(
        response => {
          response.forEach(aresta => {
            this.caminho += aresta + '  ';
          });
        },
        error => {
          console.log(error);
        }
      );
  }
}
