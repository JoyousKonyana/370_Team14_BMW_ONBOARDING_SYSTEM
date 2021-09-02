import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'search'
})
export class SearchPipe implements PipeTransform {

  transform(posts: any[], searchItem: string = ''): any {
    return posts.filter(x=> x.toLowerCase().indexOf(searchItem.toLowerCase()) > -1);
  }
  
}