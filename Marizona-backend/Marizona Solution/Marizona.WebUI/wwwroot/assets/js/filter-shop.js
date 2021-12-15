(function() {
    let field = document.querySelector('.cards');
    let li = Array.from(field.children);
    
    function FilterProduct() {
        let indicator = document.querySelector('.filter-shop').children;
    
        this.run = function() {
            for(let i=0; i<indicator.length; i++)
            {
                indicator[i].onclick = function () {
                    for(let x=0; x<indicator.length; x++)
                    {
                        indicator[x].classList.remove('active');
                    }
                    this.classList.add('active');
                    const displayItems = this.getAttribute('data-filter');
    
                    for(let z=0; z<li.length; z++)
                    {
                        li[z].style.transform = "scale(0)";
                        setTimeout(()=>{
                            li[z].style.display = "none";
                        }, 500);
    
                        if ((li[z].getAttribute('data-category') == displayItems) || displayItems == "all")
                         {
                             li[z].style.transform = "scale(1)";
                             setTimeout(()=>{
                                li[z].style.display = "block";
                            }, 500);
                         }
                    }
                };
            }
        }
    }

		new FilterProduct().run();
})();



const pageTitle = document.getElementById("page-title");
const spans = document.querySelectorAll(".category-title-sub");
const span = document.getElementById("category-span");
let spanText;

spans.forEach(span => {
    span.addEventListener('click', (e) => {
        e.preventDefault();
        spanText = e.target.innerText;
        pageTitle.innerText = spanText;
    })
});
