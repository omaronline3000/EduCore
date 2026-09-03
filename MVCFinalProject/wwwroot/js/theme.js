// Small theme behaviors: highlight active nav item and basic interactions
(function(){
  // mark active nav link based on current pathname
  try{
    const path = window.location.pathname.toLowerCase();
    document.querySelectorAll('.nav-link').forEach(function(a){
      const href = a.getAttribute('href') || '';
      if(href && path.indexOf(href.toLowerCase()) !== -1){
        a.classList.add('active');
      }
    });
  }catch(e){ console && console.warn && console.warn(e); }

  // small helper to show flash message (if any element with .flash exists)
  window.showFlash = function(message, type){
    const container = document.createElement('div');
    container.className = 'toast-container position-fixed bottom-0 end-0 p-3';
    const toast = document.createElement('div');
    toast.className = 'toast align-items-center text-bg-'+(type||'primary')+' border-0 show';
    toast.setAttribute('role','alert');
    toast.innerHTML = '<div class="d-flex"><div class="toast-body">'+(message||'')+'</div><button type="button" class="btn-close btn-close-white me-2 m-auto" data-bs-dismiss="toast" aria-label="Close"></button></div>';
    container.appendChild(toast);
    document.body.appendChild(container);
    setTimeout(()=>{ container.remove(); }, 4500);
  };
})();
