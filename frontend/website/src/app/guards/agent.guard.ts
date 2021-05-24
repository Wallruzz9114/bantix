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
export class AgentGuard implements CanActivateChild {
  constructor(private router: Router) {}

  canActivateChild(
    _childRoute: ActivatedRouteSnapshot,
    _state: RouterStateSnapshot
  ): Observable<boolean | UrlTree> | Promise<boolean | UrlTree> | boolean | UrlTree {
    const agentToken = LocalStorageUtils.getAgentToken();

    if (!agentToken) {
      this.router.navigate(['/']);
      return false;
    }

    return true;
  }
}
