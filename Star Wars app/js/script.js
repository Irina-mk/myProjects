const btnPeople = document.getElementById("btnPeople");
const btnShips = document.getElementById("btnShips");
const result = document.getElementById("result");
const loader = document.getElementById("loader");
const btnPrev = document.getElementById("btnPrev");
const btnNext = document.getElementById("btnNext");
const baseUrl = "https://swapi.dev/api/";
let pageMode = "";
let currentPage = 1;

let getPeople = page => {
    const url = `${baseUrl}people/?page=${page}`;
    toggleLoader(true);
    $.ajax({
        url: url,
        success: (data) => {
            console.log("The request succedeed!", data);
            toggleLoader(false);
            toggleNavButtons(data)
            displayPeople(data.results);
        },
        error: (err) => {
            console.log(err);
        },
    })
};

let getShips = page => {
    const shipsUrl = `${baseUrl}starships/?page=${page}`;
    toggleLoader(true);
    fetch(shipsUrl)
        .then(res => res.json())
        .then(ships => {
            console.log("The request succedeed!", ships);
            toggleLoader(false);
            toggleNavButtons(ships)
            displayShips(ships.results);
        })
        .catch(err => console.log(err));
}

const toggleLoader = toggle => {
    if (toggle)
        loader.style.display = 'block';
    else
        loader.style.display = 'none';
};

const displayPeople = people => {
    if (people != null) {
        result.innerHTML = '';
        result.innerHTML += `
    <div class="row">
  <div class="col-md-3">Name</div>
  <div class="col-md-2">Height</div>
  <div class="col-md-2">Mass</div>
  <div class="col-md-2">Gender</div>
  <div class="col-md-2">Birth Year</div>
  <div class="col-md-1">Films</div>
  </div>`;
        for (const person of people) {
            result.innerHTML += `
    <div class="row">
    <div class="col-md-3">${person.name}</div>
    <div class="col-md-2">${person.height}</div>
    <div class="col-md-2">${person.mass}</div>
    <div class="col-md-2">${person.gender}</div>
     <div class="col-md-2">${person.birth_year}</div>
    <div class="col-md-1">${person.films.length}</div>
    </div>`
        }
    } else {
        result.innerHTML += `<h2>There is something wrong with the data!</h2>`
    }
};

const displayShips = ships => {
    if (ships != null) {
        result.innerHTML = '';
        result.innerHTML += `
    <div class="row">
  <div class="col-md-2">Name</div>
  <div class="col-md-2">Model</div>
  <div class="col-md-2">Manufacturer</div>
  <div class="col-md-2">Cost</div>
  <div class="col-md-2">People capacity</div>
  <div class="col-md-2">Class</div>
  </div>
  <hr color="green"`;
        for (const ship of ships) {
            result.innerHTML += `
    <div class="row">
    <div class="col-md-2">${ship.name}</div>
    <div class="col-md-2">${ship.model}</div>
    <div class="col-md-2">${ship.manufacturer}</div>
    <div class="col-md-2">${ship.cost_in_credits}</div>
     <div class="col-md-2">${parseInt(ship.passengers) + parseInt(ship.crew)}</div>
    <div class="col-md-2">${ship.starship_class}</div>
    </div>
    <hr color="yellow">`;

        }
    } else {
        result.innerHTML += `<h2>There is something wrong with the data!</h2>`
    }
};

const toggleNavButtons = response => {
    if (response.next === null) {
        btnNext.style.display = "none";
    } else {
        btnNext.style.display = "block"
    };

    if (response.previous === null) {
        btnPrev.style.display = "none";
    } else {
        btnPrev.style.display = "block"
    }
};

const getNewPage = (pageType) => {
    ++currentPage;
    pageType === "people" ? getPeople(currentPage) : null;
    pageType === "ships" ? getShips(currentPage) : null;

};
const getPreviousPage = (pageType) => {
    --currentPage;
    pageType === "people" ? getPeople(currentPage) : null;
    pageType === "ships" ? getShips(currentPage) : null;

};



btnPeople.addEventListener("click", () => {
    currentPage = 1;
    getPeople(currentPage);
    pageMode = "people"
});
btnShips.addEventListener("click", () => {
    currentPage = 1;
    getShips(currentPage);
    pageMode = "ships";
});
btnNext.addEventListener("click", () => {
    getNewPage(pageMode);
});

btnPrev.addEventListener("click", () => {
    getPreviousPage(pageMode)
});