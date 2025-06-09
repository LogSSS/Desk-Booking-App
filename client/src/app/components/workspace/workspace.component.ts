import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CarouselComponent } from './carousel/carousel.component';

@Component({
  selector: 'workspace',
  standalone: true,
  imports: [CommonModule, CarouselComponent],
  templateUrl: './workspace.component.html',
})
export class WorkspaceComponent {
  carousel1 = [
    {
      src: 'https://s3-alpha-sig.figma.com/img/e90b/b3f8/c112a868ce37c2a7181d36e2a8b39e51?Expires=1750032000&Key-Pair-Id=APKAQ4GOSFWCW27IBOMQ&Signature=Bsh5TFBarC2unmoWNMpt~qrhDJkzeRtjGNUKUIRbxNshiEjxES1QI1bvav6feUyg5K9RarwjvL9vJ-ewM~Lu0WDL0zzgE4a6rqEJv18TeiR2j8K3~GvYG-R2KeNNelKbsCTLcVYdYJTmqOtD6tAxBzpgq35OF8fDEi9xVQ~1mfaKAzQn4jnrxYKY5mi2OF1TDKKTB3iEQwWbaATRT5YrHxPBc2rc0fqaYYsKZLRa~Bqo49QyBLAkB0QQ6txDFnxqEY~lNwr3~k5ww-g8oWhKzieLE2~VbWA6K5RoAAmPkA4~ZtDz5jEzxMBa90ZdGzeOZ9qV1lEAhSDD-u8S87V-fg__',
      alt: 'Sorry this image is not available',
    },
    {
      src: 'https://s3-alpha-sig.figma.com/img/1019/31b7/ae6f38119bf6b9fa9832610f6c6497ef?Expires=1750032000&Key-Pair-Id=APKAQ4GOSFWCW27IBOMQ&Signature=jn0WhQ7dxMo3esBV96rnJVfuWZoonJXWnzQhnLVpJO6gWWHynAqVCgdjQ5RGZeoYvPFuxkgrZFt~mtn2U8BpxkM-SLd44hzHD9Skz56TP12lrEwLSAKdoUORnQM~OYqU88nNcYWSMCRv9bR1QxvNlRgJVwqI7-257-J~gHdA~n-0pqwq~Zzj996EC8LKcSWfx566aHrJGv~F7sWeDMkOBUortxMwuMqPZUl1LymHXCuUMU~-mmr~ntbULbIRzRz0UukmWZ5oa79NHps224GR8WiKYB~G-UOFLFgBZeNJt9e93-1p8BnmsNzRPf-wVbReAhTqIbjNrD0aEV93mulcKg__',
      alt: 'Sorry this image is not available',
    },
    {
      src: 'https://s3-alpha-sig.figma.com/img/3b13/dc57/f5288df1675a9f4dc8fcaef0553a0f90?Expires=1750032000&Key-Pair-Id=APKAQ4GOSFWCW27IBOMQ&Signature=kikOr3h9NVD3Qu9o1QsVijmwycBbdsUuN-8wFvD5mXxg9JImjlnb7x3D9~6ydWeaC4WH2sWhBa9qvhTRGnNa0l8QjBSYsqwRh1Dz8t~uGCJXmqvGBOp9fYND2zr5~gz-6voNDc7eD7cTywIh5LZ-3umpimzuQf2un-Q3h1wB5hzSP28N~Xngcpbp2zLoPWHB9D3jeInFVAq99wSJk7qR0CrS7xqnOozNhRYCOaNx56AKtfx3qPlBuP3CUcqLz963-XyUE-VPoa8EpzyGuHtKNPg-lgyUTupzQXEW79XmYzFVx7S2GetrCYVm~fQMFC-LgrLJgKjgUBXHLHa6VN9rpw__',
      alt: 'Sorry this image is not available',
    },
    {
      src: 'https://s3-alpha-sig.figma.com/img/d565/3107/a69b20b64f00fb13a812060c8e0c1071?Expires=1750032000&Key-Pair-Id=APKAQ4GOSFWCW27IBOMQ&Signature=oCY8Z3M3Q-wUV9SlpSdsYf8VHcC2OnOig5g4i1FWduLNWfZKZD2nV6VAylZwb1pFeEsMixC0DONTv1REd1aegHnLCwB8IUDaF~p3N8wDC-8iI610JCOq5nmdiSJskIsIDzm6ga4R~TSr8tQzpFgZCoEmYfcmm0Z2PSAee3l~Vs-wn8DWOFd2dUxLH22T~cWOYo4JWG7AYEUBD6sxx1IUp9Vw9uxSQeXDoDfrhYcLRY6E12O-xDnIYd9yALf-~ltC0EJJYipqoGev2~55J8Clas6l2NNgH1P4OjTzrhRiWB5VAcDMxc~j0CPokIaABVfLfgdv6L6MiR1Mz9v4fRc3pg__',
      alt: 'Sorry this image is not available this image is not availableur',
    },
  ];

  carousel2 = [
    { src: 'https://i.imgur.com/2X3mKzs.png', alt: 'Alpha' },
    { src: 'https://i.imgur.com/JdLrBfz.png', alt: 'Beta' },
    { src: 'https://i.imgur.com/N0e8sOQ.png', alt: 'Gamma' },
  ];
}
