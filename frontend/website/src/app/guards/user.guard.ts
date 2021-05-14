import { Injectable } from '@angular/core';
import {
  ActivatedRouteSnapshot,
  CanActivateChild,
  Router,
  RouterStateSnapshot,
  UrlTree,
} from '@angular/router';
import { Observable } from 'rxjs';
import { LocalStorageUtils } from '../utils/storage/local-storage-utils';

@Injectable({
  providedIn: 'root',
})
export class UserGuard implements CanActivateChild {
  constructor(private router: Router) {}

  canActivateChild(
    _childRoute: ActivatedRouteSnapshot,
    _state: RouterStateSnapshot
  ): Observable<boolean | UrlTree> | Promise<boolean | UrlTree> | boolean | UrlTree {
    const userToken = LocalStorageUtils.getUserToken();

    if (!userToken) {
      this.router.navigate(['/']);
      return false;
    }

    return true;
  }
}
