import React from 'react';
import styles from './styles.css';
import Field from '../Field';

export default class App extends React.Component {
    constructor() {
        super();
        this.state = {
            score: 0,
            fieldState: {}
        };
    }

    componentDidMount() {
        document.addEventListener("keydown", this.handleKeyPress, false);

        fetch(`/api/game/field`)
            .then(res => res.json())
            .then(res => this.onReponse(res));

    }

    componentWillUnmount() {
        document.removeEventListener("keydown", this.handleKeyPress, false);
    }

    handleKeyPress = (e) => {

        this.move(e);

    }

    move = (e) => {

        if (e.keyCode >= 37 && e.keyCode <= 40) {

            let url = `/api/games/${this.keyCodes[e.keyCode]}`;

            fetch(url)
                .then(res => res.json())
                .then(res => this.onReponse(res));

            this.getScore();
        };

    }


    getScore = () => {
        fetch(`/api/game/score`)
            .then(res => res.json())
            .then(res => this.setState({ score: res }));
    }

    onReponse = (fieldState) => {

        console.log(fieldState);
        this.setState({ fieldState });
    }

    keyCodes = {
        37: "moveLeft",
        38: "moveUp",
        39: "moveRight",
        40: "moveDown"
    };

    render() {
        return (
            <div className={styles.root}>
                <div className={styles.score}>
                    Ваш счет: {this.state.score}
                </div>
                <Field fieldState={this.state.fieldState} />
            </div>
        );
    }

}